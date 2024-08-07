using Microsoft.EntityFrameworkCore;
using ProductAPI.Domains;

namespace ProductAPI.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NOTE08-S21; Database=TestProductApi;User Id=sa; Pwd=Senai@134; TrustServerCertificate=true;");
                base.OnConfiguring(optionsBuilder);
            }


        }

    }
}
