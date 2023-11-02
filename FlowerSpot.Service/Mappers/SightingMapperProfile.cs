using AutoMapper;
using FlowerSpot.Data.Entities;
using FlowerSpot.Domain.Sightings;

namespace FlowerSpot.Service.Mappers
{
    public class SightingMapperProfile : Profile
    {
        public SightingMapperProfile()
        {
            CreateMap<SightingModel, Sighting>();
            CreateMap<Sighting, SightingModel>()
                .ForMember(x => x.LikeCount, opt => opt.MapFrom(y => y.Likes.Count));            
            CreateMap<CreateSightingModel, Sighting>();
        }
    }
}