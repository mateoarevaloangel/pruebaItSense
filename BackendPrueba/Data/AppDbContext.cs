using BackendPrueba.Models;
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
        //public DbSet<Department> Employees { get; set; }
    }
}
