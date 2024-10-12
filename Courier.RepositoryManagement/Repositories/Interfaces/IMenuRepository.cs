using Courier.DataAccess.Model;
using Courier.ViewModel.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.RepositoryManagement.Repositories.Interfaces
{
    public interface IMenuRepository
    {
        Task<Menu?> GetMenuInfo(int menuId);
        Task<List<Menu>> GetMenuList(vmMenu param);
        Task<List<Menu>> GetMenuList();
        Task<int> GetMenuTotal();
        Task<bool> DeleteMenu(int id);
        Task<Menu> CreateMenu(vmMenu data);
    }
}
