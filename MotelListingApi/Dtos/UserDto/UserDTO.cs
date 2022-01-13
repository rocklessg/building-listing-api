using System.ComponentModel.DataAnnotations;

namespace MotelListingApi.Dtos.UserDto
{
    public class UserDTO : LoginUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
