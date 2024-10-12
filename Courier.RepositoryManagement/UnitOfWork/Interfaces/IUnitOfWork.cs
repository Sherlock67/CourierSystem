using Courier.RepositoryManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.RepositoryManagement.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        ILoginRepository UserLoginRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IModuleRepository ModuleRepository { get; }
        IMenuRepository MenuRepository { get; }
        IMenuPermissionRepository MenuPermissionRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        Task CompleteAsync();
    }
}
