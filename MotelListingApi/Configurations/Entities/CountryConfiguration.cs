﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotelListingApi.Data;

namespace MotelListingApi.Configurations.Entities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
        }

    }
}
