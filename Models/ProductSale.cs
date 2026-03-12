namespace SingularProducts.Models
{
    public class ProductSale
    {///Single sale transaction for a product returned from API
    
        public int SaleId {get; set;}
        public int ProductId {get; set;}
        public decimal SalePrice {get; set;}
        public int SaleQty {get; set;}
        public DateTime SaleDate {get; set;}
    }
}