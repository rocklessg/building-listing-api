using MotelListingApi.Dtos.UserDto;
using System.Threading.Tasks;

namespace MotelListingApi.Services
{
    public interface IAuthManager
    {
        Task<string> CreateToken();
        Task<bool> ValidateUser(LoginUserDTO userDTO);
    }
}