using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotelListingApi.Data;

namespace MotelListingApi.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(

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
                },

                new Hotel
                {
                    Id = 4,
                    Name = "Sandals Resort and Spa",
                    Address = "Negril",
                    CountryId = 4,
                    Rating = 4.5
                },

                new Hotel
                {
                    Id = 5,
                    Name = "Comfort Suites",
                    Address = "George Town",
                    CountryId = 3,
                    Rating = 4.3
                },

                new Hotel
                {
                    Id = 6,
                    Name = "Grand Palldium",
                    Address = "Nassua",
                    CountryId = 2,
                    Rating = 4
                }
            );
        }

    }
}

