namespace lalocation.API.Models
{
    public class BienProprietaire
    {
        public int Id { get; set; }
        public Bien Bien { get; set; }
        public Proprietaire Proprietaire { get; set; }
    }
}