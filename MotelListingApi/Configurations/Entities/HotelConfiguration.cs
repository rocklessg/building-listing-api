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
                }
            );
        }

    }
}

