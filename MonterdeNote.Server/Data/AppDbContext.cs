using Microsoft.EntityFrameworkCore;
using MonterdeNote.Server.Core.Models;

namespace MonterdeNote.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Note> Notes { get; set; }
    }
}
