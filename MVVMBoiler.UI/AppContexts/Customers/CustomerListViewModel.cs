using MVVMBoiler.Models;
using MVVMBoiler.UI.Bases;
using MVVMBoiler.UI.Services.Data;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MVVMBoiler.UI.AppContexts.Customers
{
    /// <summary>
    /// Showing list of customer.
    /// </summary>
    public class CustomerListViewModel : ViewModelBase
    {
        #region FIELD

        private readonly ICustomersRepository _customersRepository = new CustomersRepository();
        private ObservableCollection<Customer> _customers;
        private Customer _selectedCustomer;

        #endregion FIELD

        #region CTOR
        
        public CustomerListViewModel()
        {
            // Guard to check if the code is executed  in the designer 
            if(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            PlaceOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
        }

        #endregion CTOR

        #region PROPERTY/EVENT

        public event Action<int> PlaceOrderRequested = delegate { };
        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand<Customer> PlaceOrderCommand { get; private set; }
        public ObservableCollection<Customer> Customers
        {
            get => _customers; set
            {
                if(_customers != value)
                {
                    _customers = value;
                    OnPropertyChanged();
                }
            }
        }
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion PROPERTY
        
        #region UI BEHAVIOR

        public async void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>(await _customersRepository.GetAllAsync());
        }

        #endregion UI BEHAVIOR

        #region EVENT HANDLER

        private bool CanDelete()
        {
            return SelectedCustomer != null;
        }

        private void OnDelete()
        {
            Customers.Remove(SelectedCustomer);
        }

        private void OnPlaceOrder(Customer customer)
        {
            PlaceOrderRequested(customer.Id);
        }

        #endregion EVENT HANDLER
    }
}
