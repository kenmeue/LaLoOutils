using System.Collections.Generic;
using lalocation.API.Models;

namespace lalocation.API.Dtos
{
    public class LocataireForListDto
    {
        public int Id { get; set; }
        public UserForListDto User { get; set; }
        public LocataireStatut Statut { get; set; }
        public string Reference { get; set; }
        public ICollection<Bien> LocationsEnCours { get; set; }
        public ICollection<Bien> LocationsHistorique { get; set; }
    }
}