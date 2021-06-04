using Microsoft.EntityFrameworkCore;
using MVVMBoiler.DataAccess;
using MVVMBoiler.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVMBoiler.UI.Services.Data
{
    public class CustomersRepository : ICustomersRepository
    {
        AppDbContext _context = new AppDbContext();

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _context.Customer.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            if(!_context.Customer.Local.Any(c => c.Id == customer.Id))
            {
                _context.Customer.Attach(customer);
            }
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer;

        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.Id == customerId);
            if(customer != null)
            {
                _context.Customer.Remove(customer);
            }
            await _context.SaveChangesAsync();
        }
    }
}
