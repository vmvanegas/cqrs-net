using CQRS.PRACTICO.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS.PRACTICO.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
