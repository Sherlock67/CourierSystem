using Courier.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.RepositoryManagement.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRoleList();
        Task<Role?> GetRoleByID(int roleId);
        Task<bool> DeleteRole(int id);
        Task<Role> CreateRole(Role data);
    }
}
