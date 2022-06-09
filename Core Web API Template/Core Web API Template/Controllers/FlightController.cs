using Microsoft.AspNetCore.Mvc;
using Core_Web_API_Template.Models;
using Core_Web_API_Template.Services;
using Core_Web_API_Template.Exceptions;
using Core_Web_API_Template.DTOs;

namespace Core_Web_API_Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IAirportServices _defaultServices;

        public FlightController(IAirportServices defaultServices)
        {
            _defaultServices = defaultServices;
        }

        [HttpGet("{idFlight}")]
        public async Task<ActionResult<Flight_PassengerDTO>> GetDefaultModel(int idFlight)
        {
            Flight_PassengerDTO result;
            try
            {
                result = await _defaultServices.GetFlightInfoAsync(idFlight);
            }
            catch(NotFoundException e)
            {
                return NotFound(e.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Flight_PassengerDTO>> PostDefaultModel(Flight flight)
        {
            try
            {
                await _defaultServices.PostFlightAsync(flight);
            }
            catch (BadRequestException e)
            {

                return BadRequest(e.Message);
            }
            
            return Ok();
        }
    }
}
