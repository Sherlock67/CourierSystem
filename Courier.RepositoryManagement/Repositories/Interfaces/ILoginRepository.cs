using Courier.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.RepositoryManagement.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<UserLogin?> GetUserInfo(string userName, string password);
        Task<UserLogin?> GetUserInfo(string userName);
        Task<UserLogin?> GetUserInfo(int CustomerId);
        Task<List<UserLogin>> GetUserLoginList(CustomerData param);
        Task<List<UserLogin>> GetUserLoginList();
        Task<int> GetTotalUserLogin();
        Task<bool> DeleteUserLogin(int id);
        Task<UserLogin> CreateUserLogin(CustomerModel data, string hassPassword);
        Task<UserLogin?> GetUserByCustomerID(int customerID);
    }
}
