using Microsoft.EntityFrameworkCore;
using MonterdeNote.Server.Core.Models;

namespace MonterdeNote.Server.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
        public DbSet<Note> Notes { get; set; }
    }
}
