using Sistem_Point_Of_Sales.Models;

namespace Sistem_Point_Of_Sales.ViewModels
{
    public class ProductViewModel
    {
        public Products? viewModelProduct { get; set; }
        public int? productId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int ProductStock { get; set; }
        public string? ProductCategory { get; set; }
        public double? ProductPrice { get; set;}
        public Tags? viewModelTags { get; set; }
        public int TagId { get; set; }
        public string? TagName { get; set;}
    }
}
