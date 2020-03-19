using System;

namespace web.Models
{
    public class Quarantine : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string Country { get; set; }
    }
}
