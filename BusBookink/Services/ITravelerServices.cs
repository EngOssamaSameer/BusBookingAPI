using BusBookink.Models;

namespace BusBookink.Services
{
    public interface ITravelerServices
    {
        Task<List<Traveler>> GetAll();
        Task<Traveler> GetById(int id);
        Task<bool> UpdateTraveler(int id,Traveler traveler);
        Task<bool> DeleteTraveler(int id);
    }
}
