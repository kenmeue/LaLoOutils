using lalocation.API.Models;
using Microsoft.EntityFrameworkCore;

namespace lalocation.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Bien> Biens { get; set; }
        public DbSet <BienProprietaire> BienProprietaires { get; set; }
        public DbSet<BienStatut> BienStatuts { get; set; }
        public DbSet<BienType> BienTypes { get; set; }
        public DbSet<Contrat> Contrats { get; set; }
        public DbSet<ContratStatut> ContratStatuts { get; set; }
        public DbSet<ContratDocument> ContratDocuments { get; set; }
        public DbSet<ContratDocumentFournis> ContratDocumentFournis { get; set; }
        public DbSet<Locataire> Locataires { get; set; }
        public DbSet<LocataireStatut> LocataireStatuts { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<PaiementMode> PaiementModes { get; set; }
        public DbSet<PaiementMotif> PaiementMotifs { get; set; }
        public DbSet<PaiementMotifDocument> PaiementMotifDocuments { get; set; }
        public DbSet<PaiementStatut> PaiementStatuts { get; set; }
        public DbSet<Periodicite> Periodicites { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Proprietaire> Proprietaires { get; set; }
        public DbSet<ProprietaireStatut> ProprietaireStatuts { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Locataire>().Property(l => l.User.Id);
            modelBuilder.Entity<Locataire>()
            .HasMany(l => l.LocationsEnCours)
            .WithOne(b => b.LocataireEncours);

            modelBuilder.Entity<Locataire>()
            .HasMany(l => l.LocationsHistorique);
            
            modelBuilder.Entity<Bien>().Ignore( b => b.Proprietaires);
            
            modelBuilder.Entity<Proprietaire>().Ignore(p => p.Biens);
            
            
        }
    }
}