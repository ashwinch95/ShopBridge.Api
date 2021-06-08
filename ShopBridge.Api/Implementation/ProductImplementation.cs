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
            try
            {
                using (var context = new ShopBridgeContext())
                {
                    var translator = new ProductTranslator();
                    var dbProducts = context.GetProducts();

                    products = dbProducts.Select(p => translator.FromDal(p)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return products;
        }

        public async Task<ProductModel> GetProduct(int productId)
        {
            ProductModel product = new ProductModel();
            try
            {
                using (var context = new ShopBridgeContext())
                {
                    var translator = new ProductTranslator();
                    var dbProduct = await context.GetProduct(productId);

                    product = translator.FromDal(dbProduct);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return product;
        }

        public async Task<ProductModel> AddProduct(ProductModel product)
        {
            try
            {
                using (var context = new ShopBridgeContext())
                {
                    var translator = new ProductTranslator();
                    var dbProduct = translator.ToDAL(product);
                    dbProduct = await context.InsertProduct(dbProduct);   
                    
                    product = translator.FromDal(dbProduct);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return product;
        }

        public async Task<ProductModel> ModifyProduct(ProductModel product)
        {
            try
            {
                using (var context = new ShopBridgeContext())
                {
                    var translator = new ProductTranslator();
                    var dbProduct = translator.ToDAL(product);
                    dbProduct = await context.UpdateProduct(dbProduct);

                    product = translator.FromDal(dbProduct);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return product;
        }

        public async Task DeleteProduct(int productId)
        {
            try
            {
                using (var context = new ShopBridgeContext())
                {
                    await context.DeleteProduct(productId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}