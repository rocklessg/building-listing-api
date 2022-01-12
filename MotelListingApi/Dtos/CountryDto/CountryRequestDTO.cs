using System.ComponentModel.DataAnnotations;

namespace MotelListingApi.Dtos.CountryDto
{
    public class CountryRequestDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country Name should not be more than 50 characters long")]
        //Display(Name = "Country Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 3, ErrorMessage = "Short Country Name should not be more than 3 characters long")]
        public string ShortName { get; set; }
    }
}
