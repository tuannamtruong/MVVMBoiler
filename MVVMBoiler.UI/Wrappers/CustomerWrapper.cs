using MVVMBoiler.Models;
using MVVMBoiler.UI.Bases;
using System.Collections.Generic;

namespace MVVMBoiler.UI.Wrappers
{
    internal class CustomerWrapper : ModelWrapperBase<Customer>
    {
        public CustomerWrapper(Customer model) : base(model) { }

        public int Id { get => Model.Id; set => SetValue(value); } 
        public string FirstName { get => GetValue<string>(); set => SetValue(value); }
        public string LastName { get => GetValue<string>(); set => SetValue(value); }
        public List<Order> Orders { get => GetValue<List<Order>>(); set => SetValue(value); }
    }
}
