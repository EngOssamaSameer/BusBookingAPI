using BusBookink.Bl;
using BusBookink.Contexts;
using BusBookink.Models;
using Microsoft.EntityFrameworkCore;

namespace BusBookink.Services
{
    public class DestinationServices : IDestinationServices
    {        
        // Propertys
        private AppDbContext _appDbContext { get; }

        public DestinationServices(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        /* function */
        public async Task<List<Destination>> GetAll()
        {
            var result =  _appDbContext.TbDestination.ToList();
            return result;
        }

        public  Task<Destination> GetById(int id)
        {
            var result =  _appDbContext.TbDestination.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<bool> AddNewDestination(Destination Destination)
        {
            await _appDbContext.TbDestination.AddAsync(Destination);
            _appDbContext.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateDestination(int id, Destination Destination)
        {
            var iSExsit = await _appDbContext.TbDestination.FirstOrDefaultAsync(a => a.Id == id);
            if (iSExsit == null)
            {
                return false;
            }
            iSExsit.Name = Destination.Name;

            _appDbContext.TbDestination.Update(iSExsit);
            _appDbContext.SaveChanges();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var iSExsit = await _appDbContext.TbDestination.FirstOrDefaultAsync(a => a.Id == id);
            if (iSExsit == null)
            {
                return false;
            }
            _appDbContext.TbDestination.Remove(iSExsit);
            _appDbContext.SaveChanges();
            return true;
        }

    }
}
