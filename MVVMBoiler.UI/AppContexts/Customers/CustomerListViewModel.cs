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

        private readonly ICustomersRepository _customersRepository;
        private ObservableCollection<Customer> _customers;
        private Customer _selectedCustomer;

        #endregion FIELD

        #region CTOR

        public CustomerListViewModel(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
            // Guard to check if the code is executed  in the designer 
            if(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            AddCommand = new RelayCommand(OnAdd);
            PlaceOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
            EditCustomerCommand = new RelayCommand<Customer>(OnEditCustomer);
        }
   

        #endregion CTOR

        #region PROPERTY/EVENT

        public event Action<int> PlaceOrderRequested = delegate { };
        public event Action<Customer> AddCustomerRequested = delegate { };
        public event Action<Customer> EditCustomerRequested = delegate { };
        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand<Customer> PlaceOrderCommand { get; private set; }
        public RelayCommand<Customer> EditCustomerCommand { get; private set; }
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
                OnPropertyChanged();
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

        private void OnAdd()
        {
            AddCustomerRequested(new Customer());
        }
        private void OnEditCustomer(Customer customer)
        {
            EditCustomerRequested(customer);
        }


        private bool CanDelete()
        {
            return SelectedCustomer != null;
        }

        private async void OnDelete()
        {
            Customers.Remove(SelectedCustomer);
            await _customersRepository.DeleteCustomerAsync(SelectedCustomer.Id);
        }

        private void OnPlaceOrder(Customer customer)
        {
            PlaceOrderRequested(customer.Id);
        }

        #endregion EVENT HANDLER
    }
}
