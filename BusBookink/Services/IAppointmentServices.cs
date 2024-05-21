using BusBookink.Models;
using System.Runtime.CompilerServices;

namespace BusBookink.Services
{
    public interface IAppointmentServices
    {
        Task<List<Appointment>> GetAll();
        Task<Appointment> GetById(int id);
        Task<Appointment> AddNewAppointment(Appointment appointment);
        Task<bool> UpdateAppointment(int id ,Appointment appointment);
        Task<bool> Delete(int id);


    }
}
