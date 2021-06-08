namespace ShopBridge.Api.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public ProductCategoryModel Category { get; set; }
        public string Brand { get;set; }
    }

    public enum ProductCategoryModel
    {
        Electronics = 1,
        Kitchen = 2,
        Sports = 3,
        Furniture = 4,
        Games = 5,
        Books = 6
    }
}