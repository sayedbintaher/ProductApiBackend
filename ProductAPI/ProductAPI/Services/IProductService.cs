using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;

namespace ProductAPI.Services
{
    public interface IProductService
    {
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();
        Task<List<Product>> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<List<Product>> DeleteProduct(int id);
    }
}
