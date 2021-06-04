using MVVMBoiler.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVVMBoiler.UI.Services.Data
{
    public interface ICustomersRepository
    {
        Task<Customer> AddCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int customerId);
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetCustomerAsync(int id);
        Task<Customer> UpdateCustomerAsync(Customer customer);
    }
}