using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataContextFolder
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {
            DbPath = "(localdb)\\MSSQLLocalDB";
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public string DbPath { get; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    if (!options.IsConfigured)
        //    {
        //        options.UseSqlServer("A FALLBACK CONNECTION STRING");
        //    }
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"Data Source={DbPath};Initial Catalog=AngularFrontendDb;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
