using System;
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
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
