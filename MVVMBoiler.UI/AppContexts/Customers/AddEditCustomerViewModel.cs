using MVVMBoiler.Models;
using MVVMBoiler.UI.Bases;
using MVVMBoiler.UI.Wrappers;

namespace MVVMBoiler.UI.AppContexts.Customers
{
    class AddEditCustomerViewModel : ViewModelBase
    {
        private bool _editMode;
        private CustomerWrapper _customer;
        private Customer _editingCustomer = null;

        public bool EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;
                OnPropertyChanged();
            }
        }

        public void SetCustomer(Customer cust)
        {
            _editingCustomer = cust;
            Customer = new CustomerWrapper(cust);
        }
        
        public CustomerWrapper Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
    }
}
