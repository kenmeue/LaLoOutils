using System.Collections.Generic;

namespace lalocation.API.Models
{
    public class Periodicite
    {
        public int Id { get; set; }
        public ICollection<PeriodiciteDetail> PeriodiciteDetail { get; set; }
    }
}