using System.ComponentModel.DataAnnotations;

namespace BusBookink.Models
{
    public class Destination
    {
        public Destination()
        {
            TbAppointments = new HashSet<Appointment>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Appointment> TbAppointments { get; set; }
    }
}

