using System;
using System.ComponentModel;

namespace web.Models
{
    public class Quarantine : BaseEntity
    {
        [DisplayName("Date the Quarantine was inacted:")]
        public DateTime StartDate { get; set; }
        [DisplayName("Duration of Quarantine in days:")]
        public int Duration { get; set; }
        [DisplayName("Country which has undergone Quarantine:")]
        public string Country { get; set; }
        public double TimeRemaining => (StartDate.AddDays(Duration) - DateTime.Now).TotalSeconds;
    }
}
