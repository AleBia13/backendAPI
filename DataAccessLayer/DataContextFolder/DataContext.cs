using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataContextFolder
{
    public class DataContext : IdentityDbContext
    {
        public DataContext()
        {
                
        }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("A FALLBACK CONNECTION STRING");
            }
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //=> options.UseSqlServer($"Data Source={DbPath};Initial Catalog=AngularFrontendDb;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.seed
        }
    }
}
