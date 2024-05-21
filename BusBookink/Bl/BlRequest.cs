using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusBookink.Bl
{
    public class BlRequest
    {
        [Required] 
        public int TravelerId { get; set; }
        [Required]
        public int AppoinmentId { get; set; }
    }
}
