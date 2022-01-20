﻿using System.ComponentModel.DataAnnotations;

namespace MotelListingApi.Dtos.HotelDto
{
    public class HotelRequestDTO //CreateHotelDto
    {
        [Required]
        [StringLength(maximumLength: 150, ErrorMessage = "Hotel Name Is Too Long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 150, ErrorMessage = "Address Is Too Long")]
        public string Address { get; set; }

        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }

        //Relationships
        public int CountryId { get; set; }
    }
}
