using MVVMBoiler.Models;
using MVVMBoiler.UI.Bases;

namespace MVVMBoiler.UI.AppContexts.Customers
{
    class AddEditCustomerViewModel : ViewModelBase
    {
        private bool _editMode;
        private Customer _customer;
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
        }

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
    }
}
