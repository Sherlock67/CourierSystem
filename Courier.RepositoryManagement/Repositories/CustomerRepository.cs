using Courier.DataAccess.Data;
using Courier.DataAccess.Model;
using Courier.RepositoryManagement.Base;
using Courier.RepositoryManagement.Repositories.Interfaces;
using Courier.ViewModel.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.RepositoryManagement.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>,ICustomerRepository
    {
        private ApplicationDbContext? applicationDbContext => applicationDbContext as ApplicationDbContext;
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public Task<Customer> CreateCustomer(CreateCustomerModel data, string? fileName, string? extension)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> GetCustomerInfo(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> GetCustomerInfo(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomerList(CustomerData param)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomerList()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCustomerTotal()
        {
            throw new NotImplementedException();
        }
    }
}
