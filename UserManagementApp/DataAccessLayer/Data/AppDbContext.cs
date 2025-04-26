using BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
        }
    }

}
