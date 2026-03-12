using System.Text.Json;
using SingularProducts.Models;

namespace SingularProducts.Repositories
{///Handles all communication with API
    public class ProductRepository : IProductRepository
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public ProductRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var response = await _httpClient.GetAsync("products");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Product>>(json, _jsonOptions)
                ?? new List<Product>();
        }

        public async Task<List<ProductSale>> GetProductSales(int productId)
        {
            var response = await _httpClient.GetAsync($"product-sales?Id={productId}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ProductSale>>(json, _jsonOptions)
                ?? new List<ProductSale>();
        }
    }
}