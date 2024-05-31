using Courier.Business.Interface.ILogin;
using Courier.DataAccess.Model;
using Courier.RepositoryManagement.UnitOfWork.Interfaces;
using Courier.ViewModel.ViewModels;
using Courier.ViewModel.ViewModels.Customers;
using Courier.ViewModel.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Courier.Business.Services
{

    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoginService()
        {

        }
        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<object> ChangePassword(LoginModel userInfo)
        {
            throw new NotImplementedException();
        }

        public Task<object> DeycryptLoginPasswordKey(string ChangePassKey)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateNewToken(LoginModel userInfo, string userAgent, string remoteIpAddress)
        {
            throw new NotImplementedException();
        }

        public async Task<object> LoginUser(Login credential, string userAgent, string remoteIpAddress)
        {
            throw new NotImplementedException();

        }

        public Task<object> SendEmailToChangePassword(LoginModel userInfo, string userAgent, string remoteIpAddress)
        {
            throw new NotImplementedException();
        }

        public Task<object?> UserRegistration(CustomerModel data)
        {
            throw new NotImplementedException();
        }
    }
}
