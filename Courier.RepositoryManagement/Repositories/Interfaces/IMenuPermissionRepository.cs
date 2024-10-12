using Courier.DataAccess.Model;
using Courier.ViewModel.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.RepositoryManagement.Repositories.Interfaces
{
    public interface IMenuPermissionRepository
    {
        Task<MenuPermission> SetMenuPermission(vmMenuPermission data);
        Task<List<MenuPermission>> GetMenuPermissionList();
        Task<bool> DeleteMenuPermission(int id);
        Task<MenuPermission?> GetMenuPermissionByPermissionId(int permissionId);
    }
}
