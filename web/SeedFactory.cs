using web.Models;
using web.Data;
using System;
using System.Linq;

namespace web
{
    public class SeedFactory
    {
        public static void Initialize(Context context) 
        {
            context.Database.EnsureCreated();
                if (!context.Quarantines.Any()) {
                context.Quarantines.AddAsync(new Quarantine{
                    StartDate = new DateTime(2020,4,1),
                    Duration = 30,
                    Country = "USA"
                });
                context.SaveChangesAsync();
            }
        }
    }
}