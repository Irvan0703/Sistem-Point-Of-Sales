using System.ComponentModel.DataAnnotations;

namespace Sistem_Point_Of_Sales.Models
{
    public class Tags
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<ProductTags>? ProductTags { get; set; }
    }
}
