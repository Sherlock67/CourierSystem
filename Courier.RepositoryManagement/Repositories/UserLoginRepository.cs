using API.Settings;
using Courier.DataAccess.Data;
using Courier.DataAccess.Migrations;
using Courier.DataAccess.Model;
using Courier.RepositoryManagement.Base;
using Courier.RepositoryManagement.Repositories.Interfaces;
using Courier.ViewModel.ViewModels.Common;
using Courier.ViewModel.ViewModels.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.RepositoryManagement.Repositories
{
    public class UserLoginRepository : BaseRepository<UserLogin>, ILoginRepository
    {
        private ApplicationDbContext? applicationDbContext => applicationDbContext as ApplicationDbContext;
        public UserLoginRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<bool> DeleteUserLogin(int id)
        {
            return Convert.ToBoolean(DeleteAsync(await GetByIdAsync(id)).IsCompleted);
        }

        public async Task<int> GetTotalUserLogin()
        {
            return (await GetAllAsync()).Count();
        }

        public async Task<UserLogin?> GetUserByCustomerID(int customerID)
        {
            return (await GetManyAsync(filter: u => u.CustomerId == customerID)).FirstOrDefault();
        }

        public async Task<UserLogin?> GetUserInfo(string userName, string password)
        {
           return (await GetManyAsync(filter: u => u.UserName == userName && u.HashPassword == password)).FirstOrDefault();
        }

        public async Task<UserLogin?> GetUserInfo(string userName)
        {
           return (await GetManyAsync(filter: x => x.UserName == userName)).FirstOrDefault();
        }

        public Task<UserLogin?> GetUserInfo(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserLogin>> GetUserLoginList()
        {
            return (await GetAllAsync()).ToList();
        }

        public async Task<List<UserLogin>> GetUserLoginList(CustomerData param)
        {
            CommonData commonData = new CommonData()
            {
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
            };
            return (await GetManyAsync(
                filter: x => (

                !string.IsNullOrEmpty(param.Search) ? (x.UserName.Contains(param.Search)) : true

                ),
                orderBy: x => x.OrderBy(t => t.CustomerId),
                top: param.PageSize,
                skip: Common.Skip(commonData)
                )).ToList();
        }

        public async Task<UserLogin> CreateUserLogin(CustomerModel data, string hassPassword)
        {
            UserLogin obj = new UserLogin()
            {
                UserName = data.Email,
                CustomerId = data.CustomerID,
                Password = data.Password,
                HashPassword = hassPassword,
                //RoleId=data.RoleId
            };
            return await AddAsync(obj);
        }
    }
}
