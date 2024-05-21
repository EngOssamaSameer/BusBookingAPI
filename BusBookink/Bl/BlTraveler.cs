using System.ComponentModel.DataAnnotations;

namespace BusBookink.Bl
{
    public class BlTraveler
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
