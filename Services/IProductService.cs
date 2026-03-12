using SingularProducts.Models;

namespace SingularProducts.Services
{///Defines contract for business logic operations
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<ProductSalesSummary> GetProductSalesSummary(int productId);
    }
}