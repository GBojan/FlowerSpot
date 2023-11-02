using FlowerSpot.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FlowerSpot.Data
{
    public class FlowerSpotDbContext : IdentityDbContext<IdentityUser>
    {
        protected readonly IConfiguration Configuration;

        public FlowerSpotDbContext(DbContextOptions<FlowerSpotDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<Flower> Flowers { get; set; }

        public DbSet<Sighting> Sightings { get; set; }

        public DbSet<SightingQuote> SightingQuotes { get; set; }

        public DbSet<Like> Likes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseNpgsql(Configuration.GetConnectionString("FlowerSpotConnectionString"));
            }
        }
    }
}