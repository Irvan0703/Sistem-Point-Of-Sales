using Sistem_Point_Of_Sales.Models;

namespace Sistem_Point_Of_Sales.Interface
{
    public interface IProduct
    {
        Task<int> CreateProduct (Products products, Tags tags);
        Task<int> UpdateProduct (Products products, Tags tags);
        Task<int> DeleteProduct (int? id);
        Products GetProductsById (int Id);
        Task<IEnumerable<Products>> GetAllProducts();
    }
}
