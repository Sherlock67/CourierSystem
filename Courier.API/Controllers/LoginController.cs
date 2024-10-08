﻿using Courier.Business.Interface.ILogin;
using Courier.ViewModel.ViewModels;
using Courier.ViewModel.ViewModels.Customers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Courier.API.Controllers
{
    [Route("api/[controller]"), Produces("application/json"), EnableCors()]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginService loginServices;
        public LoginController(ILoginService _loginServices)
        {
            loginServices = _loginServices;
        }
        [HttpPost("[action]")]
        public async Task<object> UserLogin(Login credential)
        {
            object result = new object();
            try
            {
                string userAgent = Request.Headers["User-Agent"].ToString();
                string? RemoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

                result = await loginServices.LoginUser(credential, userAgent, RemoteIpAddress);
                if (result == null)
                {
                    result = new { message = "User not foud.", resstate = false };
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return result;
        }
        [HttpPost("[action]")]
        public async Task<object?> UserRegistration([FromBody] CustomerModel data)
        {
            object? resdata = null;
            try
            {
                resdata = await loginServices.UserRegistration(data);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return resdata;

        }
        [HttpPost("[action]")]
        public async Task<object> GenerateNewToken(LoginModel model)
        {
            string token = string.Empty; object result = new object();
            try
            {
                string userAgent = Request.Headers["User-Agent"].ToString();
                string RemoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

                token = await loginServices.GenerateNewToken(model, userAgent, RemoteIpAddress);
                if (string.IsNullOrEmpty(token))
                {
                    result = new { message = "User is not exist.", resstate = false };
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return new { token };
        }
        [HttpPost("[action]")]
        public async Task<object> ChangePassword(LoginModel model)
        {
            object result = new object();
            try
            {
                string userAgent = Request.Headers["User-Agent"].ToString();
                string RemoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

                result = await loginServices.ChangePassword(model);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return result;
        }
        [HttpPost("[action]")]
        public async Task<object> SendEmailToChangePassword(LoginModel model)
        {
            object result = new object();
            try
            {
                string userAgent = Request.Headers["User-Agent"].ToString();
                string RemoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
                result = await loginServices.SendEmailToChangePassword(model, userAgent, RemoteIpAddress);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return result;
        }

        [HttpGet("DeycryptLoginPasswordKey/{passKey}")]//, Authorizations
        public async Task<object> DeycryptLoginPasswordKey(string passKey)
        {
            object result = new object();
            try
            {
                string userAgent = Request.Headers["User-Agent"].ToString();
                string RemoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
                result = await loginServices.DeycryptLoginPasswordKey(passKey);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return result;
        }

    }
}
