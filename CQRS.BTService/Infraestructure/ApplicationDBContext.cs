using CQRS.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Infraestructure
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
            : base(options) { }
    }
}
