using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaffolding.Data.DbInfrastructure
{
    public interface IDbFactory : IDisposable
    {
        DBEntities Init();
    }

    public class DbFactory : Disposable, IDbFactory
    {
        DBEntities dbContext;

        public DBEntities Init()
        {
            return dbContext ?? (dbContext = new DBEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
