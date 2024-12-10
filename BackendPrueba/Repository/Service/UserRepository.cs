using BackendPrueba.Data;
using BackendPrueba.Models;
using BackendPrueba.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BackendPrueba.Repository.Service
{
    public class UserRepository: IUserRepository
    {
        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        private readonly AppDbContext appDbContext;


        public async Task<User> AddUser(User user)
        {
            var result = await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteUser(int userId)
        {
            var result = await appDbContext.Users
                .FirstOrDefaultAsync(e => e.Id == "");
            if (result != null)
            {
                appDbContext.Users.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<User> GetUser(int UserId)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(e => e.Id == "");
        }

        public async Task<User> GetUserByName(string userName)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(e => e.UserName == userName);
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
