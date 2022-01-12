using AutoMapper;
using MotelListingApi.Data;
using MotelListingApi.Dtos;
using MotelListingApi.Dtos.CountryDto;
using MotelListingApi.Dtos.HotelDto;

namespace MotelListingApi.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Country, CountryResponseDTO>().ReverseMap();
            CreateMap<Country, CountryRequestDTO>().ReverseMap();
            CreateMap<Hotel, HotelResponseDTO>().ReverseMap();
            CreateMap<Hotel, HotelRequestDTO>().ReverseMap();
        }
    }
}
