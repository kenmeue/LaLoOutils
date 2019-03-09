using System;

namespace lalocation.API.Models
{
    public class ContratDocumentFournis
    {
        public int Id { get; set; }
        public ContratDocument Type { get; set; }  
        public string Url { get; set; }
        public int ContratId { get; set; }
        public Contrat Contrat { get; set; }
        public DateTime DateCreation { get; set; }
    }
}