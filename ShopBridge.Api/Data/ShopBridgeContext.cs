using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ShopBridge.Api.Data
{
    public class ShopBridgeContext : DbContext
    {
        protected readonly ShopBridgeEntities Context;

        public ShopBridgeContext() : base("name=ShopBridgeContext")
        {
            Context = new ShopBridgeEntities();
        }

        public IEnumerable<Product> GetProducts()
        {
            return Context.Products;
        }

        public async Task<Product> GetProduct(int id)
        {
            Product product = await Context.Products.FindAsync(id);

            return product;
        }

        public async Task<Product> InsertProduct(Product product)
        {
            Context.Products.Add(product);
            await Context.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProduct(int productId)
        {
            Product product = await Context.Products.FindAsync(productId);

            if (product == null)
                throw new Exception("Product doesn't exist");

            Context.Products.Remove(product);

            await Context.SaveChangesAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            Context.Entry(product).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return product;
        }
    }
}
