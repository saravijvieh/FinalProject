using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class CatContext : DbContext
    {
        public CatContext (DbContextOptions<CatContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cat {get; set;}
        public DbSet<Application> Application {get; set;}
    }
}