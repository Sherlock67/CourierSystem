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
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        private ApplicationDbContext? applicationDbContext => applicationDbContext as ApplicationDbContext;
        public MenuRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Menu> CreateMenu(vmMenu data)
        {
            Menu obj = new Menu()
            {
                MenuName = data.MenuName,
                MenuIcon = data.MenuIcon,
                MenuPath = data.MenuPath,
                MenuSequence = data.MenuSequence,
                ModuleId = data.ModuleId,
                ParentId = data.ParentId,
                SubParentId = data.SubParentId,
                IsSubParent = data.IsSubParent,
                IsActive = data.IsActive
            };
            return await AddAsync(obj);
            //throw new NotImplementedException();
        }

        public async Task<bool> DeleteMenu(int id)
        {
            return Convert.ToBoolean(DeleteAsync(await GetByIdAsync(id)).IsCompleted);
        }

        public async Task<Menu?> GetMenuInfo(int menuId)
        {
            return (await GetManyAsync(filter: u => u.MenuId == menuId)).FirstOrDefault();
        }

        public async Task<List<Menu>> GetMenuList(vmMenu param)
        {
            return new List<Menu>();
            //throw new NotImplementedException();
        }

        public async Task<List<Menu>> GetMenuList()
        {
            return (await GetAllAsync()).ToList();
        }

        public async Task<int> GetMenuTotal()
        {
            return (await GetAllAsync()).Count();
        }
    }
}
