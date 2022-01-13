using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotelListingApi.Dtos;
using MotelListingApi.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotelListingApi.Controllers
{
    [Route("api/[controller]")] //attribute routing
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;


        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();
                var results = _mapper.Map<IList<CountryResponseDTO>>(countries);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCountries)}");

                return StatusCode(500, "Internal Server Error. Please try Again Later");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(q => q.Id == id, new List<string> { "Hotels" });
                var result = _mapper.Map<CountryResponseDTO>(country);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCountry)}");

                return StatusCode(500, "Internal Server Error. Please try Again Later");
            }
        }
    }
}