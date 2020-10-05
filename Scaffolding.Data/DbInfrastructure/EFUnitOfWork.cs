using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaffolding.Data.DbInfrastructure
{
    public interface IEFUnitOfWork
    {
        void Commit();
    }

    public class EFUnitOfWork : IEFUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private BNNPROEntities dbContext;

        public EFUnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public BNNPROEntities DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }

    }
}
