using Microsoft.EntityFrameworkCore;

namespace PocketProseApi.Models
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<Author> Authors { get; set; }
    }
}
