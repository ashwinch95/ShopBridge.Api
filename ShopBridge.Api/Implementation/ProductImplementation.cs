using ShopBridge.Api.Data;
using ShopBridge.Api.Implementation.Translators;
using ShopBridge.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Api.Implementation
{
    public class ProductImplementation : IProductImplementation
    {
        public List<ProductModel> GetProducts()
        {
            List<ProductModel> products = new List<ProductModel>();
            using (var context = new ShopBridgeContext())
            {
                var translator = new ProductTranslator();
                var dbProducts = context.GetProducts();

                products = dbProducts.Select(p => translator.FromDal(p)).ToList();
            }

            return products;
        }

        public async Task<ProductModel> GetProduct(int productId)
        {
            ProductModel product = null;
                        
            using (var context = new ShopBridgeContext())
            {
                var translator = new ProductTranslator();
                var dbProduct = await context.GetProduct(productId);

                if (dbProduct != null)
                {
                    product = new ProductModel();
                    product = translator.FromDal(dbProduct);
                }
            }

            return product;
        }

        public async Task<ProductModel> AddProduct(ProductModel product)
        {
            using (var context = new ShopBridgeContext())
            {
                var translator = new ProductTranslator();
                var dbProduct = translator.ToDAL(product);
                dbProduct = await context.InsertProduct(dbProduct);   
                
                product = translator.FromDal(dbProduct);
            }

            return product;
        }

        public async Task<ProductModel> ModifyProduct(ProductModel product)
        {
            using (var context = new ShopBridgeContext())
            {
                var translator = new ProductTranslator();
                var dbProduct = translator.ToDAL(product);
                dbProduct = await context.UpdateProduct(dbProduct);

                product = translator.FromDal(dbProduct);
            }

            return product;
        }

        public async Task DeleteProduct(int productId)
        {
            using (var context = new ShopBridgeContext())
            {
                await context.DeleteProduct(productId);
            }
        }
    }
}