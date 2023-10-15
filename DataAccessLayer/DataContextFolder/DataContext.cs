using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataContextFolder
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public string DbPath { get; }

        public DataContext()
        {
            DbPath = "(localdb)\\MSSQLLocalDB";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"Data Source={DbPath};Initial Catalog=AngularFrontendDb;");
    }
}
