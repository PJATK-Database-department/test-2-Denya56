using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core_Web_API_Template.Models
{
    public class Flight_Passenger
    {
        public int IdFlight { get; set; }
        [Required]
        [ForeignKey("IdFlight")]
        public Flight Flight { get; set; }
        public int IdPassenger { get; set; }
        [Required]
        [ForeignKey("IdPassenger")]
        public Passenger Passenger { get; set; }
    }
}
