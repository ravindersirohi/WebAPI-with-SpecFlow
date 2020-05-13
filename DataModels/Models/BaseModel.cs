using System;
namespace DataModels.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            CreatedOn = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
