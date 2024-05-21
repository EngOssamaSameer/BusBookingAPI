using BusBookink.Contexts;
using BusBookink.Models;
using Microsoft.EntityFrameworkCore;

namespace BusBookink.Services
{
    public class TravelerServices : ITravelerServices
    {
        // Propertys
        private AppDbContext _appDbContext { get; }

        public TravelerServices(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        /* function */
        public async Task<List<Traveler>> GetAll()
        {
            var result = _appDbContext.TbTraveler.ToList();
            return result;
        }

        public async Task<Traveler> GetById(int id)
        {
            var result =await _appDbContext.TbTraveler.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                var AppointmentsRelated = _appDbContext.TbRequest.Where(a=>a.TravelerId == result.Id);
                result.TbRequests = AppointmentsRelated.ToList();
            }
            
            return result;
        }

        public async Task<bool> UpdateTraveler(int id, Traveler traveler)
        {
            var reslut = _appDbContext.TbTraveler.FirstOrDefault(x => x.Id == id);
            if (reslut == null)
            {
                return false;
            }

            reslut.UserName = traveler.UserName;
            reslut.Email = traveler.Email;

            _appDbContext.TbTraveler.Update(reslut);
            _appDbContext.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteTraveler(int id)
        {
            var reslut = _appDbContext.TbTraveler.FirstOrDefault(x => x.Id == id);
            if (reslut == null)
            {
                return false;
            }
            _appDbContext.TbTraveler.Remove(reslut);
            _appDbContext.SaveChanges();
            return true;
        }

    }
}
