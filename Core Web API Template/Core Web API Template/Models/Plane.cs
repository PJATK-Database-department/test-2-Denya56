using System.ComponentModel.DataAnnotations;

namespace Core_Web_API_Template.Models
{
    public class Plane
    {
        [Key]
        public int IdPlane { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int MaxSeats { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}
