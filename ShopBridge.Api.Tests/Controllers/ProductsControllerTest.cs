using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ShopBridge.Api.Controllers;
using ShopBridge.Api.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;

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
        public async Task GetProductByExistingIdTest()
        {
            ProductsController controller = new ProductsController();

            var result = await controller.GetProduct(1);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetProductByNonExistantIdTest()
        {
            ProductsController controller = new ProductsController();

            var result = await controller.GetProduct(13);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetProductByInvalidIdTest()
        {
            ProductsController controller = new ProductsController();

            var result = await controller.GetProduct(-1);

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
        public async Task AddProductByRemovingMandatoryFieldsTest()
        {
            ProductsController controller = new ProductsController();

            ProductModel product = new ProductModel()
            {
                ProductName = null,
                Description = null,
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
                ProductID = 1,
                ProductName = "TV",
                Description = "TV",
                Category = ProductCategoryModel.Electronics,
                IsAvailable = true,
                Price = 82899,
                Brand = "LG"
            };

            var result = await controller.ModifyProduct(1, product);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task ModifyProductByRemovingMandatoryFieldsTest()
        {
            ProductsController controller = new ProductsController();

            ProductModel product = new ProductModel()
            {
                ProductID = 1,
                ProductName = null,
                Description = null,
                Category = ProductCategoryModel.Electronics,
                IsAvailable = true,
                Price = 8999,
                Brand = "Acer"
            };

            var result = await controller.ModifyProduct(1, product);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task ModifyProductByPassingMismatchedIdTest()
        {
            ProductsController controller = new ProductsController();

            ProductModel product = new ProductModel()
            {
                ProductID = 1,
                ProductName = null,
                Description = null,
                Category = ProductCategoryModel.Electronics,
                IsAvailable = true,
                Price = 8999,
                Brand = "Acer"
            };

            var result = await controller.ModifyProduct(2, product);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task DeleteProductTest()
        {
            ProductsController controller = new ProductsController();

            var result = await controller.DeleteProduct(44);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task DeleteNonExistantProductTest()
        {
            ProductsController controller = new ProductsController();

            var result = await controller.DeleteProduct(0);

            Assert.IsNotNull(result);
        }
    }
}
