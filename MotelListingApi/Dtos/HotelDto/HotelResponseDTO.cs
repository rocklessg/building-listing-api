namespace MotelListingApi.Dtos.HotelDto
{
    public class HotelResponseDTO : HotelRequestDTO
    {
        public int Id { get; set; }
        public CountryResponseDTO Country { get; set; }
    }
}
