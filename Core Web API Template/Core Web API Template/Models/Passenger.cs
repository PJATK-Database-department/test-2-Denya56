using System.ComponentModel.DataAnnotations;

namespace Core_Web_API_Template.Models
{
    public class Passenger
    {
        [Key]
        public int IdPassenger { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(20)]
        public string PassportNum { get; set; }
        public ICollection<Flight_Passenger> Flight_Passengers { get; set; }
    }
}
