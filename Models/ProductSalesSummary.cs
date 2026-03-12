namespace SingularProducts.Models
{
    public class ProductSalesSummary
    {///Calculated sales summary for product - calculated in Service layer from raw sales data
        public int ProductId {get; set;}
        public string ProductDescription {get; set;} = string.Empty;
        public int TotalUnitsSold {get; set;}
        public decimal TotalRevenue {get; set;}
        public DateTime? LastSaleDate {get; set;}

    }
} 