using ShopBridge.Api.Data;
using ShopBridge.Api.Models;

namespace ShopBridge.Api.Implementation.Translators
{
    public class ProductTranslator
    {
        public Product ToDAL(ProductModel product)
        {
            return new Product()
            {
                iProductID = product.ProductID,
                iProductCategoryID = (int)product.Category,
                bIsAvailable = product.IsAvailable,
                dPrice = product.Price,
                vchDescription = product.Description,
                vchProductName = product.ProductName,
                vchBrand = product.Brand
            };
        }

        public ProductModel FromDal(Product dbProduct)
        {
            return new ProductModel()
            {
                ProductID = dbProduct.iProductID,
                ProductName = dbProduct.vchProductName,
                Category = (ProductCategoryModel)dbProduct.iProductCategoryID,
                Description = dbProduct.vchDescription,
                IsAvailable = dbProduct.bIsAvailable,
                Price = dbProduct.dPrice,
                Brand = dbProduct.vchBrand
            };
        }
    }
}