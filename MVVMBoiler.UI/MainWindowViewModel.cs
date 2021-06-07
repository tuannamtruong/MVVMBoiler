using MVVMBoiler.Models;
using MVVMBoiler.UI.AppContexts.Customers;
using MVVMBoiler.UI.AppContexts.OrderPrep;
using MVVMBoiler.UI.AppContexts.Orders;
using MVVMBoiler.UI.Bases;
using System;

namespace MVVMBoiler.UI
{
    /// <summary>
    /// Setting which view is showed in which window region.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private CustomerListViewModel _customerListViewModel = new CustomerListViewModel();
        private OrderViewModel _orderViewModel = new OrderViewModel();
        private OrderPrepViewModel _orderPrepViewModel = new OrderPrepViewModel();
        private AddEditCustomerViewModel _addEditCustomerViewModel = new AddEditCustomerViewModel();
        
        private ViewModelBase currentViewModel;

        public RelayCommand<string> NavigateCommand { get; set; }
        public MainWindowViewModel()
        {
            NavigateCommand = new RelayCommand<string>(OnNavigate);
            _customerListViewModel.PlaceOrderRequested += NavToOrder;
            _customerListViewModel.AddCustomerRequested += NavToAddCustomer;
            _customerListViewModel.EditCustomerRequested += NavToEditCustomer;
        }

        private void NavToEditCustomer(Customer customer)
        {
            _addEditCustomerViewModel.EditMode = true;
            _addEditCustomerViewModel.SetCustomer(customer);
            CurrentViewModel = _addEditCustomerViewModel;
        }

        private void NavToAddCustomer(Customer customer)
        {
            _addEditCustomerViewModel.EditMode = false;
            _addEditCustomerViewModel.SetCustomer(customer);
            CurrentViewModel = _addEditCustomerViewModel;
        }

        private void NavToOrder(int customerId)
        {
            _orderViewModel.CustomerId = customerId;
            CurrentViewModel = _orderViewModel;
        }

        private void OnNavigate(string destViewModel)
        {
            switch(destViewModel)
            {
                case nameof(OrderPrepViewModel):
                    CurrentViewModel = _orderPrepViewModel;
                    break;         
                case nameof(AddEditCustomerViewModel):
                    CurrentViewModel = _addEditCustomerViewModel;
                    break;
                case nameof(CustomerListViewModel):
                default:
                    CurrentViewModel = _customerListViewModel;
                    break;
            }
        }

        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel; set
            {
                currentViewModel = value;
                OnPropertyChanged();
            }
        }

    }
}
