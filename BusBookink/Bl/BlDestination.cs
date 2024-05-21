using System.ComponentModel.DataAnnotations;

namespace BusBookink.Bl
{
    public class BlDestination
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
