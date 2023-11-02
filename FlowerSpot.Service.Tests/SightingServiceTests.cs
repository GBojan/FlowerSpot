using AutoFixture;
using AutoMapper;
using FlowerSpot.Data;
using FlowerSpot.Data.Entities;
using FlowerSpot.Domain.Flowers;
using FlowerSpot.Domain.SightingQuotes;
using FlowerSpot.Domain.Sightings;
using FlowerSpot.Service.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace FlowerSpot.Service.Tests
{
    public class SightingServiceTests
    {
        private DbContextOptions<FlowerSpotDbContext> _options;
        private IConfiguration _configuration;
        private FlowerSpotDbContext _context;
        private Fixture _fixture;
        private IMapper _mapper;

        [SetUp]
        public void Init()
        {
            _options = new DbContextOptionsBuilder<FlowerSpotDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var myConfiguration = new Dictionary<string, string>
            {
                {"Key1", "Value1"}
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();

            _context = new FlowerSpotDbContext(_options, _configuration);

            var config = new MapperConfiguration(opts =>
            {
                opts.CreateMap<SightingModel, Sighting>();
                opts.CreateMap<Sighting, SightingModel>()
                    .ForMember(x => x.LikeCount, opt => opt.MapFrom(y => y.Likes.Count));
                opts.CreateMap<CreateSightingModel, Sighting>();
                opts.CreateMap<Flower, FlowerModel>().ReverseMap();
                opts.CreateMap<SightingQuote, SightingQuoteModel>().ReverseMap();

            });

            _mapper = config.CreateMapper();
        }

        [TearDown]
        public void CleanUp()
        {
            _context.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetAllSightings_Should_Return_Two()
        {
            var sightingEntities = _fixture.CreateMany<Sighting>(2).ToList();

            await _context.Sightings.AddRangeAsync(sightingEntities);
            await _context.SaveChangesAsync();
            var sightingService = new SightingService(_context, _mapper, Substitute.For<ISightingQuotesService>());

            var sightings = await sightingService.GetAllAsync();

            Assert.IsNotNull(sightings);
            Assert.AreEqual(sightings.First().Id, sightingEntities.First().Id);
            Assert.AreEqual(sightings.Count(), sightingEntities.Count);
        }
    }
}
