using SingularProducts.Models;
using SingularProducts.Repositories;

namespace SingularProducts.Services
{///Contains all business logic for product operations
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<ProductSalesSummary> GetProductSalesSummary(int productId)
        {
            var sales = await _productRepository.GetProductSales(productId);

            if (sales == null || !sales.Any())
            {
                return null;
            }

            return new ProductSalesSummary
            {
                ProductId = productId,
                TotalUnitsSold = sales.Sum(s => s.SaleQty),
                TotalRevenue = sales.Sum(s => s.SalePrice * s.SaleQty),
                LastSaleDate = sales.Any() ? sales.Max(s => s.SaleDate) : null
            };
        }
    }
}