using System.ComponentModel.DataAnnotations;

namespace MVVMBoiler.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
