using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core_Web_API_Template.Models
{
    public class Flight
    {
        [Key]
        public int IdFlight { get; set; }
        [Required]
        public DateTime FlightDate { get; set; }
        [Required]
        [MaxLength(200)]
        public string? Comments { get; set; }
        [Required]
        public int IdPlane { get; set; }
        [Required]
        [ForeignKey("IdPlane")]
        public Plane Plane { get; set; }
        [Required]
        public int IdCityDict { get; set; }
        [Required]
        [ForeignKey("IdCityDict")]
        public CityDict CityDict { get; set; }
        public ICollection<Flight_Passenger> Flight_Passengers { get; set; }
    }
}
