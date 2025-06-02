
namespace VG.EfCore
{
    using Microsoft.EntityFrameworkCore;
    using VG.domain.Entities.Login;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!; // TODO: Add>
    }
}
