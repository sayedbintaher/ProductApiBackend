using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if(product == null)
            {
                BadRequest("No product found with that Id");
            }
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var listProducts = await _productService.GetProducts();
            return Ok(listProducts);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> CreateProduct(Product product)
        {
            var listProducts = await _productService.CreateProduct(product);
            return Ok(listProducts);
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            var dbProduct = await _productService.UpdateProduct(product);
            if(dbProduct == null)
                return BadRequest("Product Not Found");
            return Ok(dbProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var dbProduct = await _productService.DeleteProduct(id);
            if (dbProduct == null)
                return BadRequest("Product Not Found");

            return Ok(dbProduct);
        }
    }
}
