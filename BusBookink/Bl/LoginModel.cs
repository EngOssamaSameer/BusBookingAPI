using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusBookink.Bl
{
    public class LoginModel
    {
        [Required]
        [StringLength(100)]
        public string Emial { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}
