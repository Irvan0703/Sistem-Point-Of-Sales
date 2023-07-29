using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistem_Point_Of_Sales.Models
{
    public class ProductTags
    {
        [Key]
        [Column(Order =1)]
        public int ProductsId { get; set; }
        [Key]
        [Column(Order =2)]
        public int TagsId { get; set; }
        public virtual Products? Products { get; set; } 
        public virtual Tags? Tags { get; set; } 
    }
}
