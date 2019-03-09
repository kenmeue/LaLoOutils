using System.Collections.Generic;

namespace lalocation.API.Models
{
    public class Proprietaire
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ProprietaireStatut Statut { get; set; }
        public string Reference { get; set; }
        public ICollection<Bien> Biens { get; set; }
        public Adresse Adresse { get; set; }
    }
}