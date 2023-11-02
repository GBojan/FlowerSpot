using FlowerSpot.Service;
using FlowerSpot.Service.Abstractions;

namespace FlowerSpot.Api.Modules
{
    public static class ServicesModule
    {
        public static void AddServicesModule(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFlowerService, FlowerService>();
            services.AddTransient<ISightingService, SightingService>();
            services.AddTransient<ILikesService, LikesService>();
            services.AddTransient<ISightingQuotesService, SightingQuotesService>();
            services.AddSingleton<IHttpClientService, HttpClientService>();
        }
    }
}