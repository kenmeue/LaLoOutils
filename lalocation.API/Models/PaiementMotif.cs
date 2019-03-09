using System.Collections.Generic;

namespace lalocation.API.Models
{
    public class PaiementMotif
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public ICollection<PaiementMotifDocument> Documents { get; set; }
    }
}