using System;
namespace DataModels.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
