namespace lalocation.API.Models
{
    public class Adresse
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Complement { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
    }
}