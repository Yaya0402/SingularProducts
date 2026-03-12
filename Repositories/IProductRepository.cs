using SingularProducts.Models;

namespace SingularProducts.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<List<ProductSale>> GetProductSales(int productId);
    }
}

///<summary>
/// Defines the contract for data access operations
/// Any class implementing it much provide these methods 
/// for fetching data from API
/// </summary>