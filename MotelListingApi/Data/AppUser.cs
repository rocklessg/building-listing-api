using Microsoft.AspNetCore.Identity;

namespace MotelListingApi.Data
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
