using ShopBridge.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Api.Implementation
{
    interface IProductImplementation
    {
        List<ProductModel> GetProducts();
        Task<ProductModel> GetProduct(int productId);
        Task<ProductModel> AddProduct(ProductModel product);
        Task<ProductModel> ModifyProduct(ProductModel product);
        Task DeleteProduct(int productId);
    }
}
