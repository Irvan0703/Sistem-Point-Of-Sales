using Microsoft.EntityFrameworkCore;

namespace Sistem_Point_Of_Sales.Models
{
    public class AppDbClass: DbContext
    {
        public AppDbClass(DbContextOptions<AppDbClass> options) : base(options) 
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Tags> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTags>().HasKey(pt => new { pt.ProductsId, pt.TagsId });
            modelBuilder.Entity<ProductTags>()
                .HasOne(pt => pt.Products)
                .WithMany(pt => pt.ProductTags)
                .HasForeignKey(pt => pt.ProductsId);
            modelBuilder.Entity<ProductTags>()
                .HasOne(pt => pt.Tags)
                .WithMany(pt => pt.ProductTags)
                .HasForeignKey(pt =>pt.TagsId);
        }
        public DbSet<ProductTags> ProductTags { get; set; }
    }
}
