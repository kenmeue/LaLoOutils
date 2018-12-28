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

        public void SeedUsers()
        {
            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
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