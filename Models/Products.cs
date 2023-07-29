using System.ComponentModel.DataAnnotations;

namespace Sistem_Point_Of_Sales.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }       
        public string? Name { get; set; }       
        public string? Description { get; set; }
        public double Price { get; set; }
        public int stock { get; set; }
        public string? category { get; set; }
        public virtual ICollection<ProductTags>? ProductTags { get; set; } 

    }
}
