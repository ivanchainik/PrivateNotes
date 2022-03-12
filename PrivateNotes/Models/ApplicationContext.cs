using Microsoft.EntityFrameworkCore;

namespace PrivateNotes.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
