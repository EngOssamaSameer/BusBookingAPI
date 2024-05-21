using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusBookink.Models
{
    public class Request
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Traveler")]
        public int TravelerId { get; set; }
        [ForeignKey("Appointment")]
        public int AppoinmentId { get; set; }

        [Required]
        public bool Status { get; set; }//tuur if accept false if decline
    }
}
