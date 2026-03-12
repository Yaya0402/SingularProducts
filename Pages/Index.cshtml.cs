using Microsoft.AspNetCore.Mvc.RazorPages;
using SingularProducts.Models;
using SingularProducts.Services;

namespace SingularProducts.Pages
{///Page model for index page

///Responsible for fetching data from service and passing to the view for display
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public List<Product> Products { get; set; } = new List<Product>();
        public Dictionary<int, ProductSalesSummary> SalesSummaries { get; set; } = new();

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public async Task OnGetAsync()
        {
            Products = await _productService.GetAllProducts();

            foreach (var product in Products)
            {
                var summary = await _productService.GetProductSalesSummary(product.Id);
                summary.ProductDescription = product.Description;
                SalesSummaries[product.Id] = summary;
            }
        }
    }
}