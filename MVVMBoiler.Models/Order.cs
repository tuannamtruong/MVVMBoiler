using System.ComponentModel.DataAnnotations;

namespace MVVMBoiler.Models
{
    public class Order
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
