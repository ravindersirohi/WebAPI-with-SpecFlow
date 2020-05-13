using System;
using System.Collections.Generic;
namespace WebAPI.Services
{
    // Product service will pull data from some database.
    public static class ProductService<T>
    {
        internal static List<T> Products { get; set; }
        public static List<T> All()
        {
            return Products;
        }
        public static void Create(T product)
        {
            Products.Add(product);
        }
    }
}
