namespace lalocation.API.Models
{
    public class PaiementMotifDocument
    {
        public int Id { get; set; } 
        public PaiementMotif PaiementMotif { get; set; }
        public string TemplateUrl { get; set; }
    }
}