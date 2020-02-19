using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using ProjectCore.Core.Data;
using ProjectCore.Core.Data.Repository;
using ProjectCore.Core.Data.Repository.System;
using ProjectCore.Data.Repository;
using ProjectCore.Data.Repository.System;
using ProjectCore.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _DbContext;
        private SystemConfigRepository _SystemConfigRepository;
        public ISystemConfigRepository SystemConfigRepository { get { if (_SystemConfigRepository == null) _SystemConfigRepository = new SystemConfigRepository(_DbContext); return _SystemConfigRepository; } }
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this._DbContext = dbContext;
        }
        public dynamic ExcuteStore<T>(string storeName, object [] parameters)
        {

            return new { };
        }
        public void Commit()
        {
            this._DbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await this._DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _DbContext.Dispose();
        }
    }
}
