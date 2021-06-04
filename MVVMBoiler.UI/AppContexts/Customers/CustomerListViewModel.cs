using MVVMBoiler.Models;
using MVVMBoiler.UI.Services.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MVVMBoiler.UI.AppContexts.Customers
{
    public class CustomerListViewModel
    {
        private ICustomersRepository _customersRepository = new CustomersRepository();
        
        public CustomerListViewModel()
        {
            // Guard to check if the code is executed  in the designer 
            if(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;
            //Customers = new ObservableCollection<Customer>(_customersRepository.GetAllAsync().Result);
            var customersTask = Task.Run(() => _customersRepository.GetAllAsync().Result);
            Customers = new ObservableCollection<Customer>(customersTask.Result);
        }

        public ObservableCollection<Customer> Customers { get; set; }
    }
}
