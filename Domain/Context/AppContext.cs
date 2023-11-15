using Domain.Models;
using System.Data.Entity;

namespace Domain.Context
{
    public class AppContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }

        public AppContext() : base("DbConnection") 
        {
                
        }
    }
}
