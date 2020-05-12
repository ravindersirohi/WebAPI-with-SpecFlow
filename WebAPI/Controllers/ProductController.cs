using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
            Products = new List<Product>()
            {
                new Product { Id=1, Name="Milk", Quantity=2 },
                new Product { Id=2, Name="Banana", Quantity=6 },
                new Product { Id=2, Name="Apple", Quantity=4 }
            };
        }
        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Products;
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return Products.FirstOrDefault(product => product.Id == id);
        }

        // POST: api/Product
        [HttpPost]
        public void Post(Product product)
        {
            Products.Add(product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, Product product)
        {
            var find = Products.FirstOrDefault(product => product.Id == id);
            if (find != null)
            {
                find.Name = product.Name;
                find.Quantity = product.Quantity;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private List<Product> Products { get; set; }
    }
}
