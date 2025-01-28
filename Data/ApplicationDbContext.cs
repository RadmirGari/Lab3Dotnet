using CommunityApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CommunityApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Province>().HasData(
                new Province { ProvinceCode = "BC", ProvinceName = "British Columbia" },
                new Province { ProvinceCode = "ON", ProvinceName = "Ontario" },
                new Province { ProvinceCode = "QC", ProvinceName = "Quebec" }
            );

            modelBuilder.Entity<City>().HasData(
                new City { CityId = 1, CityName = "Vancouver", Population = 675000, ProvinceCode = "BC" },
                new City { CityId = 2, CityName = "Surrey", Population = 550000, ProvinceCode = "BC" },
                new City { CityId = 3, CityName = "Toronto", Population = 2731000, ProvinceCode = "ON" },
                new City { CityId = 4, CityName = "Montreal", Population = 1710000, ProvinceCode = "QC" }
            );
        }
    }
    
}
