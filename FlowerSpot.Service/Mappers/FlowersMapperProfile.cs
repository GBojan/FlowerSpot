using AutoMapper;
using FlowerSpot.Data.Entities;
using FlowerSpot.Domain.Flowers;

namespace FlowerSpot.Service.Mappers
{
    public class FlowersMapperProfile : Profile
    {
        public FlowersMapperProfile()
        {
            CreateMap<Flower, FlowerModel>().ReverseMap();
            CreateMap<CreateFlowerModel, Flower>();
        }
    }
}