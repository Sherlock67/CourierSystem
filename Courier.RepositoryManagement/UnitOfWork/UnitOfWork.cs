using Courier.DataAccess.Data;
using Courier.RepositoryManagement.Repositories;
using Courier.RepositoryManagement.Repositories.Interfaces;
using Courier.RepositoryManagement.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.RepositoryManagement.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        private ModuleRepository _moduleRepository;
        public IModuleRepository ModuleRepository => _moduleRepository ?? (_moduleRepository = new ModuleRepository(_dbContext));
        private MenuRepository _menuRepository;
        public IMenuRepository MenuRepository => _menuRepository ?? (_menuRepository = new MenuRepository(_dbContext));
        private UserLoginRepository _loginRepository;
        private CustomerRepository _customerRepository;
        public ILoginRepository UserLoginRepository => _loginRepository ?? (_loginRepository = new UserLoginRepository(_dbContext));

        public ICustomerRepository CustomerRepository => _customerRepository ?? (_customerRepository = new CustomerRepository(_dbContext));

        private MenuPermissionRepository _menuPermissionRepository;
        public IMenuPermissionRepository MenuPermissionRepository => _menuPermissionRepository ?? (_menuPermissionRepository = new MenuPermissionRepository(_dbContext));
        
        private RoleRepository _roleRepository;
        public IRoleRepository RoleRepository => _roleRepository ?? (_roleRepository = new RoleRepository(_dbContext));

        private UserRoleRepository _userRoleRepository;
        public IUserRoleRepository UserRoleRepository => _userRoleRepository ?? (_userRoleRepository = new UserRoleRepository(_dbContext));
        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
