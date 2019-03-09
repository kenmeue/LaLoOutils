using System.Collections.Generic;
using System.Threading.Tasks;
using lalocation.API.Models;
using Microsoft.EntityFrameworkCore;

namespace lalocation.API.Data
{
    public class LalocationRepository : ILalocationRepository
    {
        private readonly DataContext _context;

        public LalocationRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add<T>(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove<T>(entity);
        }

        public  async Task<IEnumerable<Locataire>> GetLocataires()
        {
            return await _context.Locataires.Include(u => u.User)
            .Include(b => b.LocationsEnCours)
            .Include(b => b.LocationsHistorique).ToListAsync();
        }

        public async Task<Locataire> GetLocataire(int id)
        {
            return await _context.Locataires.Include(u => u.User).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<User> GetUser(int id)
        {
           var user = await _context.Users.Include(p=>p.Photos).FirstOrDefaultAsync(u => u.Id == id);

           return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include( p => p.Photos).ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}