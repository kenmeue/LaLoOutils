using System;
using System.Collections.Generic;

namespace lalocation.API.Models
{
    public class Contrat
    {
        public int Id { get; set; }
        public Locataire Locataire { get; set; }
        public ContratStatut Statut { get; set; }
        public string Reference { get; set; }
        public Bien Bien { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateDebut    { get; set; }
        public DateTime? DateFin { get; set; }
        public Periodicite Periodicite { get; set; }
        public ICollection<ContratDocumentFournis> DocumentsFournis { get; set; }
    }
}