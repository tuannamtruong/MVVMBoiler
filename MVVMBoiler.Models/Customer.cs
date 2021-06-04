using System.Collections.Generic;

namespace MVVMBoiler.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
