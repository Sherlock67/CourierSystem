using Courier.DataAccess.Data;
using Courier.DataAccess.Model;
using Courier.RepositoryManagement.Base;
using Courier.RepositoryManagement.Repositories.Interfaces;
using Courier.ViewModel.ViewModels.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.RepositoryManagement.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        private ApplicationDbContext? applicationDbContext => _dbContext as ApplicationDbContext;
        public UserRoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<UserRole> CreateUserRole(CreateUserRole data)
        {
            UserRole obj = new UserRole()
            {
                RoleId = data.RoleId,
                LoginId = data.LoginId,
            };
            return await AddAsync(obj);
        }

        public async Task<bool> DeleteUserRole(int id)
        {
            return Convert.ToBoolean(DeleteAsync(await GetByIdAsync(id)).IsCompleted);
        }

        public async Task<List<UserRole>> GetUserRoleList()
        {
            return (await GetAllAsync()).ToList();
        }
        public async Task<UserRole?> GetUserRoleById(int userRoleId)
        {
            return await GetByIdAsync(userRoleId);
        }
        public async Task<UserRole?> GetUserRoleByLoginId(int loginId)
        {
            return (await GetManyAsync(filter: u => u.LoginId == loginId)).FirstOrDefault();
        }
    }
}
