using System;
using System.Threading.Tasks;
using lalocation.API.Models;
using Microsoft.EntityFrameworkCore;

namespace lalocation.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string pasword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if(user == null)
                return null;
            
            if (!VerifyPasswordHash(pasword, user.PasswwordHash, user.PasswwordSalt))
                return null;
            
            return user;
        }

        private bool VerifyPasswordHash(string pasword, byte[] passwwordHash, byte[] passwwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwwordSalt))
            {
               // passwordSalt = hmac.Key;
              var  computedHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes(pasword));
              for  (int i = 0; i < computedHash.Length; i++)
              {
                    if(computedHash[i] != passwwordHash[i])
                    return false;
              }
              return true;
            }
        }

        public async Task<User> Register(User user, string pasword)
        {
            byte[] passwordHash, passwordSalt;
            CreatepasswordHash (pasword, out passwordHash, out passwordSalt);
            user.PasswwordSalt = passwordSalt;
            user.PasswwordHash = passwordHash;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatepasswordHash(string pasword, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes(pasword));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.UserName == username))
            return true;

            return false;
        }
    }
}