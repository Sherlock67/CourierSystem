using Courier.ViewModel.ViewModels;
using Courier.ViewModel.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.Business.Interface.ILogin
{
    public interface ILoginService
    {
        Task<object> LoginUser(Login credential, string userAgent, string remoteIpAddress);
        Task<string> GenerateNewToken(LoginModel userInfo, string userAgent, string remoteIpAddress);
        Task<object> ChangePassword(LoginModel userInfo);
        Task<object> SendEmailToChangePassword(LoginModel userInfo, string userAgent, string remoteIpAddress);
        Task<object> DeycryptLoginPasswordKey(string ChangePassKey);
        Task<object?> UserRegistration(CustomerModel data);
    }
}
