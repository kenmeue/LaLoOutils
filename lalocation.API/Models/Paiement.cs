using System;
using System.Collections.Generic;

namespace lalocation.API.Models
{
    public class Paiement
    {
        public int Id { get; set; }
        public PaiementStatut Statut { get; set; }
        public Contrat Contrat { get; set; }
        public int PeriodiciteDetailId { get; set; }
        public DateTime DatePaiement { get; set; }
        public DateTime DatePaiementEffectif { get; set; }
        public int PaiementTypeId { get; set; }
        public PaiementMotif PaiementMotif { get; set; }
        public PaiementMode PaiementMode { get; set; }
        public ICollection<PaiementMotifDocument> Documents { get; set; }

    }
}