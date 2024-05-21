using BusBookink.Contexts;
using BusBookink.Models;
using Microsoft.EntityFrameworkCore;

namespace BusBookink.Services
{
    public class UserInfoServices : IUserInfoServices
    {
        // Propertys
        private AppDbContext _appDbContext { get; }

        public UserInfoServices(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        /* function */
        public async Task<List<Appointment>> GetAllAppointments()
        {
            var result = _appDbContext.TbAppointments.ToList();
            return result;
        }

        public async Task<Appointment> GetById(int id)
        {
            var result = await _appDbContext.TbAppointments.FirstOrDefaultAsync(a => a.Id == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<bool> NewRequest(Request request)
        {
            var result = _appDbContext.TbRequest.AddAsync(request);
            if(result.IsCompleted)
            {
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
            
        }

        public async Task<List<Request>> GetAllRequests(int travelerId)
        {
            return  _appDbContext.TbRequest.ToList().Where(a => a.TravelerId == travelerId).ToList();
        }

    }
}
