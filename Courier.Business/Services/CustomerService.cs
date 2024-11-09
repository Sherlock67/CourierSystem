using API.Settings;
using API.Utility;
using Courier.Business.Interface.ICustomer;
using Courier.DataAccess.Model;
using Courier.RepositoryManagement.UnitOfWork.Interfaces;
using Courier.ViewModel.ViewModels.Common;
using Courier.ViewModel.ViewModels.Customers;
using Courier.ViewModel.ViewModels.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.Business.Services
{
    public class CustomerService : ICustomer
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }
        public async Task<object?> CreateCustomer(CustomerModel data, List<AttachedFile> files)
        {

            string message = string.Empty; bool resstate = false;
            Customer objCustomer = new(); string fileName = "", fileExt = "";
            int loginId = 0, roleId = 0; string roleName = "";
            try
            {
                fileName = files.Count > 0 ? files[0].FileName : "";
                fileExt = files.Count > 0 ? files[0].Extension : "";
                objCustomer = await _unitOfWork.CustomerRepository.CreateCustomer(data, fileName, fileExt);
                await _unitOfWork.CompleteAsync();
                if (objCustomer != null)
                {
                    data.CustomerID = objCustomer.CustomerId;
                    data.RoleId = data.RoleId;
                    data.Password = data.Password;
                    string hassPassword = CommonExt.Encryptdata(data.Password);
                    var login = await _unitOfWork.UserLoginRepository.CreateUserLogin(data, hassPassword);
                    await _unitOfWork.CompleteAsync();
                    if (login != null)
                    {
                        CreateUserRole uRole = new CreateUserRole()
                        {
                            RoleId = Convert.ToInt32(data.RoleId),
                            LoginId = (int)login.LoginId
                        };
                        var ulogin = await _unitOfWork.UserRoleRepository.CreateUserRole(uRole);
                        await _unitOfWork.CompleteAsync();
                        loginId = (int)login.LoginId;
                        roleId = uRole.RoleId;
                        roleName = (await _unitOfWork.RoleRepository.GetRoleByID(uRole.RoleId))?.RoleName;
                        foreach (var file in files)
                        {
                            Common.FileSave(file, "/uploadedFile/ProfilePic");
                        }
                    }
                    message = "Created Successfully.";
                    resstate = true;
                }
                else
                {
                    message = "Failed."; resstate = false;
                }
            }
            catch (Exception ex)
            {
                message = "Failed."; resstate = false;
            }
            return new
            {
                message,
                isSuccess = resstate,
                customerId = objCustomer?.CustomerId,
                userName = objCustomer?.Email,
                firstName = objCustomer?.FirstName,
                lastName = objCustomer?.LastName,
                fullName = objCustomer?.FullName,
                email = objCustomer?.Email,
                phone = objCustomer?.Phone,
                roleId,
                roleName,
                loginId
            };
        }

        public async Task<object?> DeleteCustomer(int id)
        {
            string message = string.Empty; bool resstate = false; int total = 0;
            try
            {
                var objUserLogin = await _unitOfWork.UserLoginRepository.GetUserInfo(id);
                if (objUserLogin != null)
                {
                    await _unitOfWork.UserLoginRepository.DeleteUserLogin((int)objUserLogin.LoginId);
                }
                resstate = await _unitOfWork.CustomerRepository.DeleteCustomer(id);
                await _unitOfWork.CompleteAsync();
                message = "Deleted Successfully.";
                total = await _unitOfWork.CustomerRepository.GetCustomerTotal();
            }
            catch (Exception ex)
            {
                message = "Failed."; resstate = false;
            }
            return new
            {
                message,
                isSuccess = resstate,
                total
            };
        }

        public async Task<object?> GetCustomerByCustomerID(int id)
        {

            Customer? customer = new Customer();
            try
            {
                var objCustomer = await _unitOfWork.CustomerRepository.GetCustomerInfo(id);
                if (objCustomer != null)
                {
                    customer.CustomerId = objCustomer.CustomerId;
                    customer.LastName = objCustomer?.LastName;
                    customer.FirstName = objCustomer?.FirstName;
                    customer.Country = objCustomer?.Country;
                    customer.Email = objCustomer?.Email;
                    customer.Phone = objCustomer?.Phone;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return customer;
        }

        public async Task<object?> GetCustomerList(CustomerData param)
        {
            object list = new object(); int total = 0;
            CommonData common = new CommonData()
            {
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
            };
            try
            {
                total = (from c in await _unitOfWork.CustomerRepository.GetCustomerList()
                         join l in await _unitOfWork.UserLoginRepository.GetUserLoginList() on c.CustomerId equals l.CustomerId
                         join ur in await _unitOfWork.UserRoleRepository.GetUserRoleList() on l.LoginId equals ur.LoginId
                         join r in await _unitOfWork.RoleRepository.GetRoleList() on ur.RoleId equals r.RoleId
                         where
                         (string.IsNullOrEmpty(param.Search) ? true
                         :
                         (
                          (c.Email == null ? false : c.Email.Contains(param.Search)) ||
                           (c.FirstName == null ? false : c.FirstName.Contains(param.Search)) ||
                           (c.LastName == null ? false : c.LastName.Contains(param.Search)) ||
                           (c.Phone == null ? false : c.Phone.Contains(param.Search)) ||
                           (r.RoleName == null ? false : r.RoleName.Contains(param.Search))
                         )) &&
                         (param.roleId == 0 ? true : r.RoleId == param.roleId)
                         select c).ToList().Count();
                list = (from c in await _unitOfWork.CustomerRepository.GetCustomerList()
                        join l in await _unitOfWork.UserLoginRepository.GetUserLoginList() on c.CustomerId equals l.CustomerId
                        join ur in await _unitOfWork.UserRoleRepository.GetUserRoleList() on l.LoginId equals ur.LoginId
                        join r in await _unitOfWork.RoleRepository.GetRoleList() on ur.RoleId equals r.RoleId
                        where
                        (string.IsNullOrEmpty(param.Search) ? true
                        : (
                            (c.Email == null ? false : c.Email.Contains(param.Search)) ||
                           (c.FirstName == null ? false : c.FirstName.Contains(param.Search)) ||
                           (c.LastName == null ? false : c.LastName.Contains(param.Search)) ||
                           (c.Phone == null ? false : c.Phone.Contains(param.Search)) ||
                            (r.RoleName == null ? false : r.RoleName.Contains(param.Search))
                         )) &&
                         (param.roleId == 0 ? true : r.RoleId == param.roleId)
                        select new
                        {
                            firstName = c.FirstName,
                            lastName = c.LastName,
                            fullName = c.FullName,
                            customerId = c.CustomerId,
                            country = c.Country,
                            email = c.Email,
                            password = l.Password,
                            filePath = c.FilePath,
                            phone = c.Phone,
                            roleId = r.RoleId,
                            roleName = r.RoleName,
                            isDeleting = false,
                            total
                        }
                                ).OrderByDescending(x => x.customerId).Skip(Common.Skip(common)).Take(common.PageSize).ToList();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return new
            {
                list,
                total
            };
        }

        public async Task<int> GetCustomerTotal()
        {
            int total = 0;
            total = await _unitOfWork.CustomerRepository.GetCustomerTotal();
            return total;
        }

        public Task<string> GetFileMimeType(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]?> GetProfilePicture(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<object?> GetRoleList()
        {
            throw new NotImplementedException();
        }

        public Task<object?> UpdateCustomer(CustomerModel data, List<AttachedFile> files)
        {
            throw new NotImplementedException();
        }
    }
}
