using BusBookink.Models;

namespace BusBookink.Services
{
    public interface IRequestServices
    {
        Task<List<Request>> GetAll();
        Task<Request> GetById(int id);
        Task<bool> UpdateRequest(int id, bool Status);
    }
}
