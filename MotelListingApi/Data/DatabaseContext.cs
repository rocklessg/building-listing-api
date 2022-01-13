using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MotelListingApi.Data
{
    public class DatabaseContext : IdentityDbContext<AppUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Nigeria",
                    ShortName = "NG"
                },

                new Country
                {
                    Id = 2,
                    Name = "Jamaica",
                    ShortName = "JM"
                },

                new Country
                {
                    Id = 3,
                    Name = "Ghana",
                    ShortName = "GHA"
                }
                );

            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Adventure Ireland",
                    Address = "Nikaragua",
                    CountryId = 2,
                    Rating = 4.5
                },

                new Hotel
                {
                    Id = 2,
                    Name = "Sandlas resort and Spa",
                    Address = "Danbare street",
                    CountryId = 3,
                    Rating = 4.5
                },

                new Hotel
                {
                    Id = 3,
                    Name = "Sheraton",
                    Address = "Abuja",
                    CountryId = 1,
                    Rating = 4.3
                }
                );

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
