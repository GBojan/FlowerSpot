using FlowerSpot.Service.Mappers;

namespace FlowerSpot.Api.Modules
{
    public static class AutoMapperModule
    {
        public static void AddAutoMapperModule(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(FlowersMapperProfile),
                typeof(SightingMapperProfile),
                typeof(SightingQuoteMapperProfile),
                typeof(LikesMapperProfile)
                );
        }
    }
}