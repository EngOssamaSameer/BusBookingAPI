using Azure.Core;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusBookink.Models
{
    public class Appointment
    {
        public Appointment()
        {
            TbRequests = new HashSet<Request>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("Destination")]
        public int DestinationId { get; set; }


        public int MaxNumberOfTravellers { get; set; }

        [Required]
        public DateTime AppoinmentDate { get; set; }

        public ICollection<Request> TbRequests { get; set; }
    }
}

