using System.ComponentModel.DataAnnotations;

namespace BusBookink.Models
{
    public class Traveler
    {
        public Traveler()
        {
            //TbAppointments = new HashSet<Appointment>();
            TbRequests = new HashSet<Request>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        //public ICollection<Appointment> TbAppointments { get; set; }
        public ICollection<Request> TbRequests { get; set; }
    }
}

