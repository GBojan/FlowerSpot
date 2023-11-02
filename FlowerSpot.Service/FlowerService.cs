using AutoMapper;
using FlowerSpot.Data;
using FlowerSpot.Data.Entities;
using FlowerSpot.Domain.Flowers;
using FlowerSpot.Service.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FlowerSpot.Service
{
    public class FlowerService : IFlowerService
    {
        private readonly FlowerSpotDbContext _context;
        private readonly IMapper _mapper;

        public FlowerService(FlowerSpotDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FlowerModel>> GetAllAsync()
        {
            var flowers = await _context.Flowers.AsNoTracking().ToListAsync();

            return _mapper.Map<List<FlowerModel>>(flowers);
        }

        public async Task<FlowerModel> GetByIdAsync(int id)
        {
            var flower = await _context.Flowers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<FlowerModel>(flower);
        }

        public async Task<FlowerModel> CreateAsync(CreateFlowerModel model, string userId)
        {
            var flower = _mapper.Map<Flower>(model);
            flower.UserId = userId;

            _context.Flowers.Add(flower);
            _context.SaveChanges();

            return await GetByIdAsync(flower.Id);
        }
    }
}