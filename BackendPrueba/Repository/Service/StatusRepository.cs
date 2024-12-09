using BackendPrueba.Data;
using BackendPrueba.Models;
using BackendPrueba.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BackendPrueba.Repository.Service
{
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext appDbContext;
        //constructor del repositorio
        public StatusRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Status> AddStatus(Status status)
        {
            var result = await appDbContext.Status.AddAsync(status);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteStatus(int statusId)
        {
            var result = await appDbContext.Status.FirstOrDefaultAsync(e => e.StatusId == statusId);
            if (result != null)
            {
                appDbContext.Status.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Status> GetStatus(int statusId)
        {
            return await appDbContext.Status.FirstOrDefaultAsync(e => e.StatusId == statusId);
        }

        public async Task<IEnumerable<Status>> GetStatusAll()
        {
            return await appDbContext.Status.ToListAsync();
        }

        public async Task<Status> UpdateStatus(Status status)
        {
            var result = await appDbContext.Status
                .FirstOrDefaultAsync(e => e.StatusId == status.StatusId);

            if (result != null)
            {
                result.Name = status.Name;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
