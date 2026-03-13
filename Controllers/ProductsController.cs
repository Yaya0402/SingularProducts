using Microsoft.AspNetCore.Mvc;
using SingularProducts.Models;
using SingularProducts.Services;

namespace SingularProducts.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService =  productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}/summary")]
        public async Task<ActionResult<ProductSalesSummary>> GetProductSummary(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Product ID must be a positive number.");
            }

            var summary = await _productService.GetProductSalesSummary(id);

            if (summary == null)
            {
                return NotFound($"Product with ID {id} was not found. ");
            }
            return Ok(summary);
        }
    }
}