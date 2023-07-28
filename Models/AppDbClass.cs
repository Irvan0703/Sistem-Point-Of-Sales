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
        public DbSet<ProductTags> ProductTags { get; set; }
    }
}
