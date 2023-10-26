using Inventory.BAL.Services;
using Inventory.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace InventoryApi.Controllers
{
    //localhost:84923/api/Product
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductService _productService;
        public ProductController(ProductService productService)
        {
                _productService= productService;
        }
        [HttpGet("GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            return _productService.GetProducts();
        }
        [HttpGet("GetProductById")]
        public Product GetProductById(int ProductId)
        {
            return _productService.GetProductById(ProductId);
        }
        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int ProductId)
        {
            _productService.DeleteProduct(ProductId);
            return Ok("Product deleted Successfully");
        }
        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody]Product product)
        {
            _productService.UpdateProduct(product);
            return Ok("Product updated successfully");
        }
        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody]Product product)
        {
            _productService.AddProduct(product);
            return Ok("Product created successfully");
        }
    }
}
