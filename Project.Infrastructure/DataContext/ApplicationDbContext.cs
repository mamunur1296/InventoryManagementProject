using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;

namespace Project.Infrastructure.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Customer>? Customers { get; set; }



    }
}
