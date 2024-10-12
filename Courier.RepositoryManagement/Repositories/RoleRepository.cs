using Courier.DataAccess.Data;
using Courier.DataAccess.Model;
using Courier.RepositoryManagement.Base;
using Courier.RepositoryManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Courier.RepositoryManagement.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private ApplicationDbContext? applicationDbContext => _dbContext as ApplicationDbContext;
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<Role> CreateRole(Role data)
        {
            return await AddAsync(data);
        }

        public async Task<bool> DeleteRole(int id)
        {
            return Convert.ToBoolean(DeleteAsync(await GetByIdAsync(id)).IsCompleted);
        }

        public async Task<Role?> GetRoleByID(int roleId)
        {
            return await GetByIdAsync(roleId);
        }

        public async Task<List<Role>> GetRoleList()
        {
            List<Role> list = new List<Role>();
            list = (await GetAllAsync()).ToList().Count() > 0 ? (await GetAllAsync()).ToList() : list;
            return list;
        }
    }
}
