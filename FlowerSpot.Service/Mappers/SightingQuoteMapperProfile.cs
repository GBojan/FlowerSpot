using AutoMapper;
using FlowerSpot.Data.Entities;
using FlowerSpot.Domain.SightingQuotes;

namespace FlowerSpot.Service.Mappers
{
    public class SightingQuoteMapperProfile : Profile
    {
        public SightingQuoteMapperProfile()
        {
            CreateMap<SightingQuote, SightingQuoteModel>().ReverseMap();
        }
    }
}