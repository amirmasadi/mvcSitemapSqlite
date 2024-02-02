using Microsoft.EntityFrameworkCore;
using mvcSitemapSqlite.Models;
using System.Runtime.CompilerServices;

namespace mvcSitemapSqlite.Data
{
    public class ProductsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlite("Data Source=" + Directory.GetCurrentDirectory() + @"\mvcSitemapSqlite.db;"));
        }
        public DbSet<Product> Product { get; set; }
    }
}
