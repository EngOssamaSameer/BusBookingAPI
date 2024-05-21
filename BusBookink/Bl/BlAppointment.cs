using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusBookink.Bl
{
    public class BlAppointment
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public int DestinationId { get; set; }

        [Required]
        public int MaxNumberOfTravellers { get; set; }

        [Required]
        public DateTime AppoinmentDate { get; set; }
    }
}
