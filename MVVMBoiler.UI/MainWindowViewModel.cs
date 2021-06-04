using MVVMBoiler.UI.AppContexts.Customers;

namespace MVVMBoiler.UI
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            CurrentViewModel = new CustomerListViewModel();
        }

        public object CurrentViewModel { get; set; }
    }
}
