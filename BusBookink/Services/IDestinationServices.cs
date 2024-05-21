using BusBookink.Models;

namespace BusBookink.Services
{
    public interface IDestinationServices
    {
        Task<List<Destination>> GetAll();
        Task<Destination> GetById(int id);
        Task<bool> AddNewDestination(Destination Destination);
        Task<bool> UpdateDestination(int id, Destination Destination);
        Task<bool> Delete(int id);
    }
}
