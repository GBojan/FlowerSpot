using AutoMapper;
using FlowerSpot.Data.Entities;
using FlowerSpot.Domain.Likes;

namespace FlowerSpot.Service.Mappers
{
    public class LikesMapperProfile : Profile
    {
        public LikesMapperProfile()
        {
            CreateMap<Like, LikeModel>().ReverseMap();
        }
    }
}