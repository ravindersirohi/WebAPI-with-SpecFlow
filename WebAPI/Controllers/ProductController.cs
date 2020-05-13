using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DataModels.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService<Product>.All();
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return ProductService<Product>.All().FirstOrDefault(product => product.Id == id);
        }

        // POST: api/Product
        [HttpPost]
        public void Post(Product product)
        {
            ProductService<Product>.Create(product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, Product product)
        {
            var find = ProductService<Product>.Products.FirstOrDefault(product => product.Id == id);
            if (find != null)
            {
                find.Name = product.Name;
                find.Quantity = product.Quantity;
            }
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var find = ProductService<Product>.Products.FirstOrDefault(product => product.Id == id);
            if (find != null)
            {
                ProductService<Product>.Products.Remove(find);
            }
        }
    }
}
