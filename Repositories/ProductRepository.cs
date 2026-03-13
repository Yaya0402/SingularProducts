using System.Text.Json;
using SingularProducts.Models;

namespace SingularProducts.Repositories
{///Handles all communication with API
    public class ProductRepository : IProductRepository
    {
        private readonly HttpClient _httpClient;
        
        public ProductRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>("products");
            return products ?? new List<Product>();
        }

        public async Task<List<ProductSale>> GetProductSales(int productId)
        {
            var sales = await _httpClient.GetFromJsonAsync<List<ProductSale>>($"product-sales?Id={productId}");
            return sales ?? new List<ProductSale>();
        }
    }
}