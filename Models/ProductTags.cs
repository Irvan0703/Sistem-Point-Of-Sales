using System.ComponentModel.DataAnnotations;

namespace Sistem_Point_Of_Sales.Models
{
    public class ProductTags
    {
        [Key]
        public int Id { get; set; }
        public Products Products { get; set; } = null!;
        public Tags Tags { get; set; } = null!;
    }
}
