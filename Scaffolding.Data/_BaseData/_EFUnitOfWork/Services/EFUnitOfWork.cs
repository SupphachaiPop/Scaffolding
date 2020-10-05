using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.Data
{
    public class EFUnitOfWork : IEFUnitOfWork
    {
        private DBEntities _dbContext;

        public EFUnitOfWork(DBEntities dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Commit()
        {
            this._dbContext.Commit();
        }
            
        public void CommitAsync()
        {
            this._dbContext.CommitAsync();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (this._dbContext == null)
            {
                return;
            }

            this._dbContext.Dispose();
            this._dbContext = null;
        }
    }
}
