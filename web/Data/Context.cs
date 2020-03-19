using Microsoft.EntityFrameworkCore;
using web.Models;

namespace web.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> context) : base(context)
        {
        }
        public DbSet<Quarantine> Quarantines { get; set; }
    }
}