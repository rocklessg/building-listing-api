using MotelListingApi.Dtos.HotelDto;
using System.Collections.Generic;

namespace MotelListingApi.Dtos.CountryDto
{
    public class UpdateCountryDTO : CountryRequestDTO
    {
        public IList<HotelRequestDTO> Hotels { get; set; }
    }
}
