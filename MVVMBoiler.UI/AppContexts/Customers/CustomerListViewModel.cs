using MVVMBoiler.Models;
using MVVMBoiler.UI.Bases;
using MVVMBoiler.UI.Services.Data;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

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

            var customersTask = Task.Run(() => _customersRepository.GetAllAsync().Result);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            Customers = new ObservableCollection<Customer>(customersTask.Result);
        }

        public RelayCommand DeleteCommand { get; private set; }
        public ObservableCollection<Customer> Customers { get => _customers; set => _customers = value; }

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
