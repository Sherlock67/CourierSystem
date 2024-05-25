using Courier.DataAccess.Data;
using Courier.DataAccess.Model;
using Courier.RepositoryManagement.Base;
using Courier.RepositoryManagement.Repositories.Interfaces;
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
        public Task<bool> DeleteUserLogin(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalUserLogin()
        {
            throw new NotImplementedException();
        }

        public Task<UserLogin?> GetUserByCustomerID(int customerID)
        {
            throw new NotImplementedException();
        }

        public Task<UserLogin?> GetUserInfo(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserLogin?> GetUserInfo(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<UserLogin?> GetUserInfo(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserLogin>> GetUserLoginList()
        {
            throw new NotImplementedException();
        }
    }
}
