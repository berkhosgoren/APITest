using APItest.Entities;
using Microsoft.EntityFrameworkCore;

namespace APItest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }
        public DbSet<Testers> AllTesters { get; set; }
    }
}
