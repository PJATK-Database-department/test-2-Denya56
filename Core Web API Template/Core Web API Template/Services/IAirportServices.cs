using Core_Web_API_Template.DTOs;
using Core_Web_API_Template.Models;

namespace Core_Web_API_Template.Services
{
    public interface IAirportServices
    {
        //Task<IEnumerable<Passenger>> GetDefaultModelsAsync();
        Task<Flight_PassengerDTO> GetFlightInfoAsync(int idFlight);
        //Task PutDefaultModelAsync(int idDefaultModel, Passenger defaultModel);
        Task PostFlightAsync(Flight flight);
        //Task DeleteDefaultModelAsync(int idDefaultModel);
    }
}
