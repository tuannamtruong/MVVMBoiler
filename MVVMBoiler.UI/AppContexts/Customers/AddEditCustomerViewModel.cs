using MVVMBoiler.Models;
using MVVMBoiler.UI.Bases;
using MVVMBoiler.UI.Wrappers;
using System;

namespace MVVMBoiler.UI.AppContexts.Customers
{
    class AddEditCustomerViewModel : ViewModelBase
    {
        private bool _editMode;
        private CustomerWrapper _customer;
        private Customer _editingCustomer = null;

        public AddEditCustomerViewModel()
        {
            SaveCommand = new RelayCommand(OnSave, CanSave) ;
            CancelCommand = new RelayCommand(OnCancel);
        }

        private bool CanSave()
        {
            return true;
        }

        private void OnCancel()
        {
            AddOrEditDone();
        }

        private void OnSave()
        {
            AddOrEditDone();
        }

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
        public event Action AddOrEditDone = delegate { };
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }


    }
}
