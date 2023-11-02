using FlowerSpot.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerSpot.Api.Modules
{
    public static class DbContextModule
    {
        public static void AddDbContextModule(this IServiceCollection services, IConfiguration configuration)
        {
            if (string.IsNullOrWhiteSpace(configuration["ConnectionStrings:FlowerSpotConnectionString"]))
            {
                throw new Exception("ConnectionStrings:FlowerSpotConnectionString cannot be empty in IConfiguration");
            }

            services.AddDbContext<FlowerSpotDbContext>
                (opt => opt.UseNpgsql(configuration.GetConnectionString("FlowerSpotConnectionString")));
        }
    }
}