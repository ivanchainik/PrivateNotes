using Microsoft.EntityFrameworkCore;

namespace WebAppSavePrivateNotes.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
