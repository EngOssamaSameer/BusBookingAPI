using BusBookink.Contexts;
using BusBookink.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusBookink.Services
{
    public class AppointmentServices : IAppointmentServices
    {
        // Propertys
        private AppDbContext _appDbContext { get; }

        public AppointmentServices(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        /* function */

        public async Task<List<Appointment>> GetAll()
        {
            var result = _appDbContext.TbAppointments.ToList();
            return result;
        }

        public Task<Appointment> GetById(int id)
        {
            var result = _appDbContext.TbAppointments.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Appointment> AddNewAppointment(Appointment appointment)
        {
            await _appDbContext.TbAppointments.AddAsync(appointment);
            _appDbContext.SaveChanges();
            return appointment;
        }

        public async Task<bool> UpdateAppointment(int id, Appointment appointment)
        {
            var iSExsit = await _appDbContext.TbAppointments.FirstOrDefaultAsync(a=>a.Id == id);
            if (iSExsit == null)
            {
                return false;
            }
            iSExsit.Title = appointment.Title;
            iSExsit.AppoinmentDate = appointment.AppoinmentDate;
            iSExsit.DestinationId = appointment.DestinationId;
            iSExsit.MaxNumberOfTravellers = appointment.MaxNumberOfTravellers;

            _appDbContext.TbAppointments.Update(iSExsit);
            _appDbContext.SaveChanges();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var iSExsit = await _appDbContext.TbAppointments.FirstOrDefaultAsync(a => a.Id == id);
            if (iSExsit == null)
            {
                return false;
            }
            _appDbContext.TbAppointments.Remove(iSExsit);
            _appDbContext.SaveChanges();
            return true;
        }


    }
}
