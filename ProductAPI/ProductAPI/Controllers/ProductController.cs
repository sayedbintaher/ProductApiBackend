using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _db;
        public ProductController(DataContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return Ok(await _db.Products.FindAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await _db.Products.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> CreateProduct(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return Ok(await _db.Products.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            var dbProduct = await _db.Products.FindAsync(product.Id);
            if(dbProduct == null)
                return BadRequest("Product Not Found");

            dbProduct.ImageLink = product.ImageLink;
            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Price = product.Price;
            dbProduct.Stock= product.Stock;

            await _db.SaveChangesAsync();
            return Ok(dbProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var dbProduct = await _db.Products.FindAsync(id);
            if (dbProduct == null)
                return BadRequest("Product Not Found");

            _db.Products.Remove(dbProduct);
            await _db.SaveChangesAsync();
            return Ok(await _db.Products.ToListAsync());
        }
    }
}
