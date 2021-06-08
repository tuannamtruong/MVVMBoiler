using MVVMBoiler.Models;
using MVVMBoiler.UI.Bases;
using MVVMBoiler.UI.Services.Data;
using MVVMBoiler.UI.Ultilities;
using MVVMBoiler.UI.Wrappers;
using System;
using System.ComponentModel;

namespace MVVMBoiler.UI.AppContexts.Customers
{
    /// <summary>
    /// Create new or update existed customer against the DB.
    /// </summary>
    class AddEditCustomerViewModel : ViewModelBase
    {
        #region FIELD

        private bool _editMode;
        private readonly ICustomersRepository _customersRepository;

        public CustomerWrapper OriginalCustomer { get; private set; }

        private CustomerWrapper customer;

        #endregion FIELD

        #region CTOR

        public AddEditCustomerViewModel(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        #endregion CTOR

        public void SetCustomer(Customer customer)
        {
            if(EditMode)
                OriginalCustomer = new CustomerWrapper(MasterUltility.Clone(customer));
            if(Customer != null)
                Customer.ErrorsChanged -= RaiseCanExecuteChanged;
            Customer = new CustomerWrapper(customer);
            Customer.ErrorsChanged += RaiseCanExecuteChanged;
        }

        #region PROPERTY/EVENT

        public bool EditMode
        {
            get { return _editMode; }
            set { _editMode = value; }
        }

        public event Action AddOrEditDone = delegate { };
        public CustomerWrapper Customer
        {
            get => customer;
            set
            {
                customer = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        #endregion PROPERTY/EVENT

        #region EVENT HANDLER
        private void RaiseCanExecuteChanged(object sender, DataErrorsChangedEventArgs e)
                    => SaveCommand.RaiseCanExecuteChanged();

        private void OnCancel()
        {
            Customer.Copy(OriginalCustomer);
            OnPropertyChanged(nameof(Customer));
            AddOrEditDone();
        }

        private bool CanSave()
            => !Customer.HasErrors;

        private async void OnSave()
        {
            if(EditMode)
                await _customersRepository.UpdateCustomerAsync(Customer.Model);
            else
                await _customersRepository.AddCustomerAsync(Customer.Model);
            AddOrEditDone();
        }

        #endregion EVENT HANDLER
    }
}
