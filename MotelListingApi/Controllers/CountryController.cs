using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotelListingApi.Data;
using MotelListingApi.Data.Pagination;
using MotelListingApi.Dtos;
using MotelListingApi.Dtos.CountryDto;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountries([FromQuery] RequestParams requestParams)
        {

            var countries = await _unitOfWork.Countries.GetPagedList(requestParams);
            var results = _mapper.Map<IList<CountryResponseDTO>>(countries);
            return Ok(results);


        }


        [HttpGet("{id:int}", Name = "GetCountry")]
        [ResponseCache(CacheProfileName = "120SecondsDuration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountry(int id)
        {

            var country = await _unitOfWork.Countries.Get(q => q.Id == id, new List<string> { "Hotels" });
            var result = _mapper.Map<CountryResponseDTO>(country);
            return Ok(result);

        }


        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateCountry([FromBody] CountryRequestDTO countryDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateCountry)}");
                return BadRequest(ModelState);
            }

            var country = _mapper.Map<Country>(countryDto);

            //if (countryDto.Name == country.Name.ToString())
            //{
            //    _logger.LogError($"The country already exist in the database {nameof(CreateCountry)}");
            //    return BadRequest("Add new Country");
            //}
            await _unitOfWork.Countries.Insert(country);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetCountry", new { id = country.Id }, country);
        }


        [Authorize]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateCountry(int id, [FromBody] UpdateCountryDTO countryDto)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCountry)}");
                return BadRequest(ModelState);
            }

            var country = await _unitOfWork.Countries.Get(q => q.Id == id);
            if (country == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCountry)}");
                return BadRequest("Invalid Data");
            }

            _mapper.Map(countryDto, country);
            _unitOfWork.Countries.Update(country);
            await _unitOfWork.Save();

            return NoContent(); //204
        }


        [Authorize]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCountry)}");
                return BadRequest();
            }

            var country = await _unitOfWork.Countries.Get(q => q.Id == id);
            if (country == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCountry)}");
                return BadRequest("Invalid Data");
            }

            await _unitOfWork.Countries.Delete(id);
            await _unitOfWork.Save();

            return NoContent(); //204
        }
    }
}