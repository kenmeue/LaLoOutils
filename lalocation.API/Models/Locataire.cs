using System.Collections.Generic;

namespace lalocation.API.Models
{
    public class Locataire
    {
        public int Id { get; set; }
        public User User { get; set; }
        public LocataireStatut Statut { get; set; }
        public string Reference { get; set; }
        public ICollection<Bien> LocationsEnCours { get; set; }
        public ICollection<Bien> LocationsHistorique { get; set; }
        
    }
}