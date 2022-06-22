using Core_Web_API_Template.Context;
using Core_Web_API_Template.DTOs;
using Core_Web_API_Template.Exceptions;
using Core_Web_API_Template.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_Web_API_Template.Services
{
    public class AirportServices : IAirportServices
    {
        private readonly AirportDbContext _defaultContext;
        public AirportServices(AirportDbContext defaultContext)
        {
            _defaultContext = defaultContext;
        }
        public async Task<Flight_PassengerDTO> GetFlightInfoAsync(int idFlight)
        {
            if (_defaultContext.Flights == null)
            {
                throw new NotFoundException("No defaultModels found");
            }
            var flight = await _defaultContext.Flights
                .Include(a => a.Flight_Passengers)
                .ThenInclude(b => b.Passenger)
                .Where(f => f.IdFlight == idFlight)
                .Select(x => new Flight_PassengerDTO
                {
                    IdFlight = x.IdFlight,
                    FlightDate = x.FlightDate,
                    Comments = x.Comments,
                    IdPlane = x.IdPlane,
                    Plane = x.Plane,
                    IdCityDict = x.IdCityDict,
                    CityDict = x.CityDict,
                    Passengers = x.Flight_Passengers.Select(c => new Passenger
                    {
                        IdPassenger = c.Passenger.IdPassenger,
                        FirstName = c.Passenger.FirstName,
                        LastName = c.Passenger.LastName,
                        PassportNum = c.Passenger.PassportNum
                    })
                    .ToList()
                })
                .OrderBy(z => z.FlightDate)
                .FirstAsync();

            if (flight == null)
            {
                throw new NotFoundException("defaultmodel does not exists");
            }

            return flight;
        }
        public async Task PostFlightAsync(Flight flight)
        {
            var plane = await _defaultContext.Planes.FindAsync(flight.IdPlane);
            if (plane == null)
            {
                _defaultContext.Planes.Add(flight.Plane);
            }
            else if(await _defaultContext.Flights.FirstAsync(f => f.IdPlane == plane.IdPlane) != null)
            {
                throw new BadRequestException("Plane is already assigned to a different flight");
            }

            _defaultContext.Flights.Add(flight);
            await _defaultContext.SaveChangesAsync();
        }
    }
}
