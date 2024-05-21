using BusBookink.Contexts;
using BusBookink.Models;
using Microsoft.EntityFrameworkCore;

namespace BusBookink.Services
{
    public class RequestServices : IRequestServices
    {
        // Propertys
        private AppDbContext _appDbContext { get; }

        public RequestServices(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        /* function */
        public async Task<List<Request>> GetAll()
        {
            var result = _appDbContext.TbRequest.ToList();
            return result;
        }

        public async  Task<Request> GetById(int id)
        {
            var rsult = await _appDbContext.TbRequest.FirstOrDefaultAsync(x => x.Id == id);
            if (rsult == null)
            {
                return null;
            }
            return rsult;
        }

        public async Task<bool> UpdateRequest(int id, bool Status)
        {
            var rsult = _appDbContext.TbRequest.FirstOrDefault(x => x.Id == id);
            if (rsult == null)
            {
                return false;
            }
            rsult.Status = Status;
            _appDbContext.TbRequest.Update(rsult);
            _appDbContext.SaveChanges();
            return true;
        }
    }
}
