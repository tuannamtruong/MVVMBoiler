using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVVMBoiler.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }
        public int Id { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
