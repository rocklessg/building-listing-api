using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MotelListingApi.Data;

namespace MotelListingApi.Extensions
{
    public static class ServiceExtensions
    {
        //Extend configurations here in order not to congest the startup
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<AppUser>(q => q.User.RequireUniqueEmail = true);
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
        }
    }
}
