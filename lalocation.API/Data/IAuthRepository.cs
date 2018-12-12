using System.Threading.Tasks;
using lalocation.API.Models;

namespace lalocation.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register (User user, string pasword);
         Task<User> Login (string  username, string pasword);
         Task<bool> UserExists (string username);
    }
}