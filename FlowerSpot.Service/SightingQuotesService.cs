using FlowerSpot.Data;
using FlowerSpot.Data.Entities;
using FlowerSpot.Domain.SightingQuotes;
using FlowerSpot.Service.Abstractions;
using Microsoft.Extensions.Configuration;

namespace FlowerSpot.Service
{
    public class SightingQuotesService : ISightingQuotesService
    {
        private readonly FlowerSpotDbContext _context;
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;

        public SightingQuotesService(FlowerSpotDbContext context,
            IHttpClientService httpClientService,
            IConfiguration configuration)
        {
            _context = context;
            _httpClientService = httpClientService;
            _configuration = configuration;
        }

        public async Task CreateAsync(int sightingId)
        {
            var parameters = new Dictionary<string, string>
            {
                {"language", "en" },
                {"category", GetRandomCategory() }
            };

            var result = await _httpClientService.GetAsync<GetSightingQuoteModel>(_configuration["QuotesOfTheDay:BaseUrl"], parameters);
            var quote = result.Contents.Quotes.First();

            await _context.SightingQuotes.AddAsync(new SightingQuote
            {
                SightingId = sightingId,
                Author = quote.Author,
                Description = quote.Quote,
                Category = quote.Category
            });

            await _context.SaveChangesAsync();
        }

        private static string GetRandomCategory()
        {
            var randomNumber = new Random().Next(1, 8);

            return randomNumber switch
            {
                1 => "art",
                2 => "funny",
                3 => "inspire",
                4 => "life",
                5 => "love",
                6 => "management",
                7 => "sports",
                8 => "students",
                _ => "art",
            };
        }
    }
}