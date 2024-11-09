using Courier.ViewModel.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.Business.Interface.IRole
{
    public interface IRoleQueries
    {
        Task<object?> GetRoleList(CustomerData search);
    }
}
