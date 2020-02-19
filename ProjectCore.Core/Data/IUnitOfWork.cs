using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCore.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
         Task<int> CommitAsync();
        void Commit();
        dynamic ExcuteStore<T>(string storeName, object[] parameters);
    }
}
