using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Services
{
    public class ProductService : IProductService 
    {
        private readonly DataContext _db;

        public ProductService(DataContext db)
        {
            _db = db;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _db.Products.FindAsync(id);
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            var listProducts = await _db.Products.ToListAsync();
            return listProducts;
        }
        public async Task<List<Product>> CreateProduct(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return (await _db.Products.ToListAsync());

        }
        public async Task<Product> UpdateProduct(Product product)
        {
            var dbProduct = await _db.Products.FindAsync(product.Id);
            if(dbProduct == null)
            {
                return null;
            }
            dbProduct.ImageLink = product.ImageLink;
            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Price = product.Price;
            dbProduct.Stock = product.Stock;
            await _db.SaveChangesAsync();
            return dbProduct;
        }

        public async Task<List<Product>> DeleteProduct(int id)
        {
            var dbProduct = await _db.Products.FindAsync(id);
            if(dbProduct == null)
            {
                return null;
            }
            _db.Products.Remove(dbProduct);
            await _db.SaveChangesAsync();
            return await _db.Products.ToListAsync();
        }

       
    }
}
