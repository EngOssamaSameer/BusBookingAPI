using BusBookink.Models;

namespace BusBookink.Services
{
    public interface IUserInfoServices
    {
        Task<List<Appointment>> GetAllAppointments();

        Task<Appointment> GetById(int id);

        Task<bool> NewRequest(Request request);

        Task<List<Request>> GetAllRequests(int travelerID);



    }
}
