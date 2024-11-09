using Courier.DataAccess.Model;
using Courier.ViewModel.ViewModels.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.Business.Interface.IRole
{
    public interface IRoleCommands
    {
        Task<object?> DeleteRole(int id);
        Task<object?> AddRole(vmRole role);
        Task<object?> UpdateRole(vmRole role);
    }
}
