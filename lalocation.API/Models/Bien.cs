using System;
using System.Collections.Generic;

namespace lalocation.API.Models
{
    public class Bien
    {
        public int Id { get; set; }
        public BienType Type { get; set; }
        public BienStatut Statut { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public DateTime DateDebutExploitation { get; set; }
        public DateTime DateFinExploitation { get; set; }
        public Adresse Adresse { get; set; }
        public Locataire LocataireEncours { get; set; }
        public ICollection<Contrat> Contrats { get; set; }
        public ICollection<Proprietaire> Proprietaires { get; set; }
    }
}