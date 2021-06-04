using MVVMBoiler.Models;
using MVVMBoiler.UI.Bases;
using MVVMBoiler.UI.Services.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MVVMBoiler.UI.AppContexts.Customers
{
    public class CustomerListViewModel : ViewModelBase
    {
        private ICustomersRepository _customersRepository = new CustomersRepository();
        private ObservableCollection<Customer> _customers;

        public CustomerListViewModel()
        {
            // Guard to check if the code is executed  in the designer 
            if(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        }
        
        public RelayCommand DeleteCommand { get; private set; }
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

        private Customer _selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        public async void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>(await _customersRepository.GetAllAsync());
        }

        #region ICommand

        private bool CanDelete()
        {
            return SelectedCustomer != null;
        }

        private void OnDelete()
        {
            Customers.Remove(SelectedCustomer);
        }

        #endregion ICommand
    }
}
