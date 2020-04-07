using System;
using System.ComponentModel;

namespace web.Models
{
    public class Quarantine : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Country { get; set; }
        public double TimeRemaining => (StartDate.AddDays(Duration) - DateTime.Now).TotalSeconds;
    }
}
