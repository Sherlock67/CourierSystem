using Courier.DataAccess.Model;
using Courier.ViewModel.ViewModels.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.RepositoryManagement.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<UserRole> CreateUserRole(CreateUserRole data);
        Task<List<UserRole>> GetUserRoleList();
        Task<bool> DeleteUserRole(int id);
    }
}
