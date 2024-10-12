using Courier.DataAccess.Data;
using Courier.DataAccess.Model;
using Courier.RepositoryManagement.Base;
using Courier.RepositoryManagement.Repositories.Interfaces;
using Courier.ViewModel.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.RepositoryManagement.Repositories
{
    public class MenuPermissionRepository : BaseRepository<MenuPermission>, IMenuPermissionRepository
    {
        private ApplicationDbContext? applicationDbContext => _dbContext as ApplicationDbContext;
        public MenuPermissionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<bool> DeleteMenuPermission(int id)
        {
            return Convert.ToBoolean(DeleteAsync(await GetByIdAsync(id)).IsCompleted);
        }

        public async Task<MenuPermission?> GetMenuPermissionByPermissionId(int permissionId)
        {
            return (await GetManyAsync(filter: u => u.PermissionId == permissionId)).FirstOrDefault();
        }

        public async Task<List<MenuPermission>> GetMenuPermissionList()
        {
            return (await GetAllAsync()).ToList();
        }

        public async Task<MenuPermission> SetMenuPermission(vmMenuPermission data)
        {
            MenuPermission obj = new MenuPermission()
            {
                MenuId = data.MenuId,
                CanCreate = data.CanCreate,
                CanDelete = data.CanDelete,
                CanEdit = data.CanEdit,
                CanView = data.CanView,
                UserId = data.UserId,
                RoleId = data.RoleId,
                IsActive = data.IsActive
            };
            return await AddAsync(obj);
        }
    }
}
