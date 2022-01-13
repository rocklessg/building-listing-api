using System.ComponentModel.DataAnnotations;

namespace MotelListingApi.Dtos.UserDto
{
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Your Passwor Limited to {3} characters", MinimumLength = 3)]
        public string Password { get; set; }
    }
}
