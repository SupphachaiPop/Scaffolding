using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.Data
{
    public interface IEFUnitOfWork : IDisposable
    {
        void Commit();
        void CommitAsync();
    }
}
