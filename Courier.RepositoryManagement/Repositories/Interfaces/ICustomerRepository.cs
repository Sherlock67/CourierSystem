﻿using Courier.DataAccess.Model;
using Courier.ViewModel.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.RepositoryManagement.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetCustomerInfo(int customerId);
        Task<Customer?> GetCustomerInfo(string email);
        Task<List<Customer>> GetCustomerList(CustomerData param);
        Task<List<Customer>> GetCustomerList();
        Task<int> GetCustomerTotal();
        Task<bool> DeleteCustomer(int id);
        Task<Customer> CreateCustomer(CreateCustomerModel data, string? fileName, string? extension);
    }
}
