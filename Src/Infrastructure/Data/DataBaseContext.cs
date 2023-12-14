using Core.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataBaseContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DataBaseContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG

            optionsBuilder
               .UseSqlServer("Server=.;Initial Catalog=OnlineShopDB;Persist Security Info=True;MultipleActiveResultSets=true;User ID=sa;Password=123;TrustServerCertificate=Yes");

#endif
            base.OnConfiguring(optionsBuilder);

        }
    }
}
