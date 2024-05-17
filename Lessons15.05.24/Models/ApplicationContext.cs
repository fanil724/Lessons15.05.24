using Microsoft.EntityFrameworkCore;

namespace Lessons15._05._24.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options) {
            Database.EnsureCreated();
        }

    }
}
