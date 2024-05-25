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

        private UserLoginRepository _loginRepository;
        public ILoginRepository UserLoginRepository => _loginRepository ?? (_loginRepository = new UserLoginRepository(_dbContext));
        
        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
