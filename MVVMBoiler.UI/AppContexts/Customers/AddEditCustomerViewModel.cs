using MVVMBoiler.Models;
using MVVMBoiler.UI.Bases;

namespace MVVMBoiler.UI.AppContexts.Customers
{
    class AddEditCustomerViewModel : ViewModelBase
    {
        private bool _editMode;

        public bool EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;
                OnPropertyChanged();
            }
        }

        private Customer _editingCustomer = null;

        public void SetCustomer(Customer cust)
        {
            _editingCustomer = cust;
        }
    }
}
