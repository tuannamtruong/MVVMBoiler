using MVVMBoiler.Models;
using MVVMBoiler.UI.Bases;
using MVVMBoiler.UI.Services.Data;
using MVVMBoiler.UI.Wrappers;
using System;
using System.ComponentModel;

namespace MVVMBoiler.UI.AppContexts.Customers
{
    class AddEditCustomerViewModel : ViewModelBase
    {
        private bool _editMode;
        private readonly ICustomersRepository _customersRepository ;

        public AddEditCustomerViewModel(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        private bool CanSave()
        {
            return !Customer.HasErrors;
        }

        private void OnCancel()
        {
            AddOrEditDone();
        }

        private async void OnSave()
        {
            if(EditMode)
                await _customersRepository.UpdateCustomerAsync(Customer.Model);
            else
                await _customersRepository.AddCustomerAsync(Customer.Model);
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
            if(Customer != null)
                Customer.ErrorsChanged -= RaiseCanExecuteChanged;
            Customer = new CustomerWrapper(cust);
            Customer.ErrorsChanged += RaiseCanExecuteChanged;
        }

        private void RaiseCanExecuteChanged(object sender, DataErrorsChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public CustomerWrapper Customer { get; set; }
        public event Action AddOrEditDone = delegate { };
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
    }
}
