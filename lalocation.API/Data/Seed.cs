using System;
using System.Collections.Generic;
using lalocation.API.Models;
using Newtonsoft.Json;

namespace lalocation.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

    public void SeedAll()
    {
        var locataire =new Locataire{ Id=1, Reference ="Ref1",Statut = new LocataireStatut{Id=1,Libelle="test statut"},User = new User{Id=1}  } ;
        // locataire.Id
        locataire.User.Photos = new List<Photo>();
        locataire.User.Photos.Add(new Photo());
        var monBien = new Bien();
        monBien.Adresse = new Adresse();
        
         locataire.LocationsEnCours = new List<Bien>();
         locataire.LocationsEnCours.Add(monBien);
         locataire.LocationsHistorique = new List<Bien>();
         locataire.LocationsHistorique.Add(monBien);

        GetJsonFromEntity<Locataire>(locataire);
       /* SeedBienStatutsSeed();
        SeedBienTypes();
        SeedContratDocument();
        SeedContratStatut();
        SeedLocataireStatut();
        SeedPaiementMode();
        SeedPaiementMotif();
        SeedPaiementMotifDocument();
        SeedPaiementStatut();
        SeedPeriodicite();
        SeedProprietaireStatut();
        SeedUsers();
        
        SeedLocataires();*/
    }
    private string GetJsonFromEntity<T>(T entity) 
    {
        Console.WriteLine("Welcome to the C# Station Tutorial!"); 
       var json = Newtonsoft.Json.JsonConvert.SerializeObject(entity);
       Console.WriteLine(json);
       return json;
    }
      public void SeedBienStatutsSeed()
        {
            var data = System.IO.File.ReadAllText("Data/Seed/BienStatutSeedData.json");
                    var lstBienStatuts = JsonConvert.DeserializeObject<List<BienStatut>>(data);
            foreach ( var item in lstBienStatuts)   
            {
                _context.BienStatuts.Add(item);
            }  
            _context.SaveChanges();
        }
        public void SeedBienTypes ()
        {
            var data = System.IO.File.ReadAllText("Data/Seed/BienTypeSeedData.json");
                    var lstBienTypes = JsonConvert.DeserializeObject<List<BienType>>(data);
            foreach ( var item in lstBienTypes)   
            {
                _context.BienTypes.Add(item);
            }  
            _context.SaveChanges();
        }
         public void SeedContratDocument()
        {
            var data = System.IO.File.ReadAllText("Data/Seed/ContratDocumentSeedData.json");
                    var lstContratDocumentData = JsonConvert.DeserializeObject<List<ContratDocument>>(data);
            foreach ( var item in lstContratDocumentData)   
            {
                _context.ContratDocuments.Add(item);
            }  
            _context.SaveChanges();
        }
        public void SeedContratStatut()
        {
            var data = System.IO.File.ReadAllText("Data/Seed/ContratStatutSeedData.json");
                    var lstContratStatutData = JsonConvert.DeserializeObject<List<ContratStatut>>(data);
            foreach ( var item in lstContratStatutData)   
            {
                _context.ContratStatuts.Add(item);
            }  
            _context.SaveChanges();
        }
        public void SeedLocataireStatut()
        {
            var data = System.IO.File.ReadAllText("Data/Seed/LocataireStatutSeedData.json");
                    var lstLocataireStatutData = JsonConvert.DeserializeObject<List<LocataireStatut>>(data);
            foreach ( var item in lstLocataireStatutData)   
            {
                _context.LocataireStatuts.Add(item);
            }  
            _context.SaveChanges();
        }
        public void SeedPaiementMode()
        {
            var data = System.IO.File.ReadAllText("Data/Seed/PaiementModeSeedData.json");
                    var lstPaiementModeData = JsonConvert.DeserializeObject<List<PaiementMode>>(data);
            foreach ( var item in lstPaiementModeData)   
            {
                _context.PaiementModes.Add(item);
            }  
            _context.SaveChanges();
        }
        public void SeedPaiementMotif()
        {
            var data = System.IO.File.ReadAllText("Data/Seed/PaiementMotifSeedData.json");
                    var lstPaiementModeData = JsonConvert.DeserializeObject<List<PaiementMotif>>(data);
            foreach ( var item in lstPaiementModeData)   
            {
                _context.PaiementMotifs.Add(item);
            }  
            _context.SaveChanges();
        }
        public void SeedPaiementMotifDocument()
        {
            var data = System.IO.File.ReadAllText("Data/Seed/PaiementMotifDocumentSeedData.json");
                    var lstPaiementMotifDocumentData = JsonConvert.DeserializeObject<List<PaiementMotifDocument>>(data);
            foreach ( var item in lstPaiementMotifDocumentData)   
            {
                _context.PaiementMotifDocuments.Add(item);
            }  
            _context.SaveChanges();
        }
        public void SeedPaiementStatut()
        {
            var data = System.IO.File.ReadAllText("Data/Seed/PaiementStatutSeedData.json");
                    var lstPaiementStatutData = JsonConvert.DeserializeObject<List<PaiementStatut>>(data);
            foreach ( var item in lstPaiementStatutData)   
            {
                _context.PaiementStatuts.Add(item);
            }  
            _context.SaveChanges();
        }
        public void SeedPeriodicite()
        {
            var data = System.IO.File.ReadAllText("Data/Seed/PeriodiciteSeedData.json");
                    var lstPeriodiciteData = JsonConvert.DeserializeObject<List<Periodicite>>(data);
            foreach ( var item in lstPeriodiciteData)   
            {
                _context.Periodicites.Add(item);
            }  
            _context.SaveChanges();
        }
        public void SeedProprietaireStatut()
        {
            var data = System.IO.File.ReadAllText("Data/Seed/ProprietaireStatutSeedData.json");
                    var lstProprietaireStatutData = JsonConvert.DeserializeObject<List<ProprietaireStatut>>(data);
            foreach ( var item in lstProprietaireStatutData)   
            {
                _context.ProprietaireStatuts.Add(item);
            }  
            _context.SaveChanges();
        }
         public void SeedLocataires()
        {
            var locataireData = System.IO.File.ReadAllText("Data/Seed/LocataireSeedData.json");
            var locataires = JsonConvert.DeserializeObject<List<Locataire>>(locataireData);
            foreach (var locataire in locataires)
            {
                byte [] passwordHash, passwordSalt;
                CreatepasswordHash ("password", out passwordHash, out passwordSalt);
                locataire.User.PasswwordSalt = passwordSalt;
                locataire.User.PasswwordHash = passwordHash;
                locataire.User.UserName = locataire.User.UserName.ToLower();

                _context.Locataires.Add(locataire);
            }

            _context.SaveChanges();
        }

        public void SeedUsers()
        {
            var userData = System.IO.File.ReadAllText("Data/Seed/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users)
            {
                byte [] passwordHash, passwordSalt;
                CreatepasswordHash ("password", out passwordHash, out passwordSalt);
                user.PasswwordSalt = passwordSalt;
                user.PasswwordHash = passwordHash;
                user.UserName = user.UserName.ToLower();

                _context.Users.Add(user);
            }

            _context.SaveChanges();
        }
        private void CreatepasswordHash(string pasword, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes(pasword));
            }
        }
    }
}