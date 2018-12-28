using System.Collections.Generic;
using System.Threading.Tasks;
using lalocation.API.Models;

namespace lalocation.API.Data
{
    public interface ILalocationRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}