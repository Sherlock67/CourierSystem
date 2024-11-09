using Courier.ViewModel.ViewModels.Common;
using Courier.ViewModel.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.Business.Interface.ICustomer
{
    public interface ICustomer
    {
        Task<object?> DeleteCustomer(int id);
        Task<object?> GetCustomerByCustomerID(int id);
        Task<object?> GetCustomerList(CustomerData param);
        Task<object?> CreateCustomer(CustomerModel data, List<AttachedFile> files);
        Task<object?> UpdateCustomer(CustomerModel data, List<AttachedFile> files);
        Task<int> GetCustomerTotal();
        Task<object?> GetRoleList();
        Task<byte[]?> GetProfilePicture(string fileName);
        Task<string> GetFileMimeType(string fileName);
    }
}
