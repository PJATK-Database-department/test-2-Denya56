using System.ComponentModel.DataAnnotations;

namespace Core_Web_API_Template.Models
{
    public class CityDict
    {
        [Key]
        public int IdCityDict { get; set; }
        [Required]
        [MaxLength(30)]
        public string City { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}
