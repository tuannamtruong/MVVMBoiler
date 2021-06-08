using MVVMBoiler.Models;
using MVVMBoiler.UI.AppContexts.Customers;
using MVVMBoiler.UI.AppContexts.OrderPrep;
using MVVMBoiler.UI.AppContexts.Orders;
using MVVMBoiler.UI.Bases;
using MVVMBoiler.UI.Services.Data;

namespace MVVMBoiler.UI
{
    /// <summary>
    /// Setting which view is showed in which window region.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private CustomerListViewModel _customerListViewModel;
        private OrderViewModel _orderViewModel = new OrderViewModel();
        private OrderPrepViewModel _orderPrepViewModel = new OrderPrepViewModel();
        private AddEditCustomerViewModel _addEditCustomerViewModel;

        private ViewModelBase currentViewModel;

        public RelayCommand<string> NavigateCommand { get; set; }
        public MainWindowViewModel(ICustomersRepository customersRepository)
        {
            _addEditCustomerViewModel = new AddEditCustomerViewModel(customersRepository);
            _customerListViewModel = new CustomerListViewModel(customersRepository);
            NavigateCommand = new RelayCommand<string>(OnNavigate);
            _customerListViewModel.PlaceOrderRequested += NavToOrder;
            _customerListViewModel.AddCustomerRequested += NavToAddCustomer;
            _customerListViewModel.EditCustomerRequested += NavToEditCustomer;
            _addEditCustomerViewModel.AddOrEditDone += NavToCustomerList;
        }

        private void NavToCustomerList()
        {
            CurrentViewModel = _customerListViewModel;
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
            CurrentViewModel = destViewModel switch
            {
                nameof(OrderPrepViewModel) => _orderPrepViewModel,
                nameof(AddEditCustomerViewModel) => _addEditCustomerViewModel,
                _ => _customerListViewModel,
            };
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
