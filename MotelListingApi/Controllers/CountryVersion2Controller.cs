using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotelListingApi.Data;
using System.Threading.Tasks;

namespace MotelListingApi.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")] // [Route("api/{v:apiversion}/country")]
    [ApiController]
    
    public class CountryVersion2Controller : ControllerBase
    {
        private DatabaseContext _context;


        public CountryVersion2Controller(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCountries() => Ok(_context.Countries);

    }
}
