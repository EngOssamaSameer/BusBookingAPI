using BusBookink.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusBookink.Contexts
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        //MyPropertys
        public virtual DbSet<UserRole> TbUserRoles { get; set; }

        public virtual DbSet<Appointment> TbAppointments { get; set; }

        public virtual DbSet<Destination> TbDestination { get; set; }

        public virtual DbSet<Request> TbRequest { get; set; }

        public virtual DbSet<Traveler> TbTraveler { get; set; }

        //Constractor
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }



    }
}
