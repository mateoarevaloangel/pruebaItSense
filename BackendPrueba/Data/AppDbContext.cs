using BackendPrueba.Models;
using BackendPrueba.Repository.Service;
using Microsoft.EntityFrameworkCore;

namespace BackendPrueba.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
