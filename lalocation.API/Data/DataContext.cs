using lalocation.API.Models;
using Microsoft.EntityFrameworkCore;

namespace lalocation.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Value> Values { get; set; }
    }
}