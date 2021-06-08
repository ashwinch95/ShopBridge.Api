using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridge.Api.Controllers;
using ShopBridge.Api.Models;
using System.Threading.Tasks;

namespace ShopBridge.Api.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void GetProductsTest()
        {
            ProductsController controller = new ProductsController();
            
            var result = controller.GetProducts();
            
            Assert.IsNotNull(result);            
        }

        [TestMethod]
        public async Task GetProductByIdTest()
        {
            ProductsController controller = new ProductsController();

            var result = await controller.GetProduct(13);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task AddProductTest()
        {
            ProductsController controller = new ProductsController();

            ProductModel product = new ProductModel()
            {
                ProductName = "Monitor",
                Description = "Monitor",
                Category = ProductCategoryModel.Electronics,
                IsAvailable = true,
                Price = 8999,
                Brand = "Acer"
            };

            var result = await controller.AddProduct(product);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task ModifyProductTest()
        {
            ProductsController controller = new ProductsController();

            ProductModel product = new ProductModel()
            {
                ProductID = 13,
                ProductName = "Monitor",
                Description = "Monitor",
                Category = ProductCategoryModel.Electronics,
                IsAvailable = true,
                Price = 8999,
                Brand = "Dell"
            };

            var result = await controller.ModifyProduct(13, product);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task DeleteProductTest()
        {
            ProductsController controller = new ProductsController();

            var result = await controller.DeleteProduct(13);

            Assert.IsNotNull(result);
        }
    }
}
