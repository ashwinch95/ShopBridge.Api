using ShopBridge.Api.Implementation;
using ShopBridge.Api.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopBridge.Api.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        private readonly IProductImplementation implementation = new ProductImplementation();

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetProducts()
        {
            List<ProductModel> products;

            try
            {
                products = implementation.GetProducts();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

            if (products == null || products.Count == 0)
                return StatusCode(HttpStatusCode.NoContent);

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            ProductModel product;
            try
            {
                product = await implementation.GetProduct(id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            if (product == null)
                return StatusCode(HttpStatusCode.NoContent);

            return Ok(product);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IHttpActionResult> AddProduct([FromBody]ProductModel product)
        {
            ProductModel output;
            try
            {
                output = await implementation.AddProduct(product);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(output);
        }

        [HttpPut]
        [Route("Modify/{id}")]
        public async Task<IHttpActionResult> ModifyProduct(int id, [FromBody]ProductModel product)
        {
            if (id != product.ProductID)
                return BadRequest();

            ProductModel output;
            try
            {
                output = await implementation.ModifyProduct(product);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(output);
        }        

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            try
            {
                await implementation.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }
    }
}