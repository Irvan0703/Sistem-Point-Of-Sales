using Microsoft.EntityFrameworkCore;
using Sistem_Point_Of_Sales.Models;

namespace Sistem_Point_Of_Sales.Interface
{
    public class ProductDetail : IProduct
    {
        private readonly AppDbClass _appDbClass;
        public ProductDetail (AppDbClass appDbClass)
        {
            _appDbClass = appDbClass;
        }
        public async Task<int> CreateProduct(Products products, Tags tags)
        {
            if(products != null)
            {
                await _appDbClass.Products.AddAsync(products);
                await _appDbClass.Tags.AddAsync(tags);
                await _appDbClass.SaveChangesAsync();
                return products.Id;
            }
            return 0;
        }
        public async Task<int> UpdateProduct(Products products, Tags tags)
        {
            if(products != null)
            {
                _appDbClass.Products.Update(products);
                await _appDbClass.SaveChangesAsync();
                return products.Id;
            }
            return 0;
        }
        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            if(_appDbClass.Products != null)
            {
                return await _appDbClass.Products.ToListAsync();
            }
            return null;
        }
        public async Task<int> DeleteProduct(int? id)
        {
            int Getresult = 0;

            if (id != null)
            {
                var rec_id = await _appDbClass.Products.FirstOrDefaultAsync(Empid => Empid.Id == id);
                if (rec_id != null)
                {
                    _appDbClass.Remove(_appDbClass.Products.Single(Empid => Empid.Id == id));
                    Getresult = await _appDbClass.SaveChangesAsync();
                }
                return Getresult;

            }
            return Getresult;
        }
        public Products GetProductsById(int Id)
        {
            if(_appDbClass.Products != null)
            {
                return _appDbClass.Products.SingleOrDefault(p => p.Id == Id);
            }
            return null;
        }
    }
}
