using Core_Web_API_Template.Models;

namespace Core_Web_API_Template.DTOs
{
    public class Flight_PlaneDTO
    {
        public int IdFlight { get; set; }
        public DateTime FlightDate { get; set; }
        public string? Comments { get; set; }
        public int IdPlane { get; set; }
        public Plane Plane { get; set; }
        public int IdCityDict { get; set; }
        public CityDict CityDict { get; set; }
        public ICollection<Flight_Passenger> Flight_Passengers { get; set; }
    }
}
