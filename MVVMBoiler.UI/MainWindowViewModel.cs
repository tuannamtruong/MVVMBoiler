using MVVMBoiler.UI.AppContexts.Customers;
using MVVMBoiler.UI.AppContexts.OrderPrep;
using MVVMBoiler.UI.AppContexts.Orders;
using MVVMBoiler.UI.Bases;
using System;

namespace MVVMBoiler.UI
{
    public class MainWindowViewModel : ViewModelBase
    {
        private CustomerListViewModel _customerListViewModel = new CustomerListViewModel();
        private OrderViewModel _orderViewModel = new OrderViewModel();
        private OrderPrepViewModel _orderPrepViewModel = new OrderPrepViewModel();
        private ViewModelBase currentViewModel;

        public RelayCommand<string> NavigateCommand { get; set; }
        public MainWindowViewModel()
        {
            NavigateCommand = new RelayCommand<string>(OnNavigate);
        }

        private void OnNavigate(string destViewModel)
        {
            switch(destViewModel)
            {
                case nameof(OrderPrepViewModel):
                    CurrentViewModel = _orderPrepViewModel;
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
