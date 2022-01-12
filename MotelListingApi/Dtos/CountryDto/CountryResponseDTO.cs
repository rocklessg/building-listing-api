using MotelListingApi.Dtos.CountryDto;
using MotelListingApi.Dtos.HotelDto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotelListingApi.Dtos
{
    public class CountryResponseDTO : CountryRequestDTO
    {
        public int Id { get; set; }
        public IList<HotelResponseDTO> Hotels { get; set; }
    }
}
