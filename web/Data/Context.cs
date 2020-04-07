using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using web.Models;

namespace web.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> context) : base(context)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=quarantineContext.db");
        public DbSet<Quarantine> Quarantines { get; set; }
    }
}