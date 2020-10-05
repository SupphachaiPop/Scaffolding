﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaffolding.Data.DbInfrastructure
{
    public interface IDbFactory : IDisposable
    {
        BNNPROEntities Init();
    }

    public class DbFactory : Disposable, IDbFactory
    {
        BNNPROEntities dbContext;

        public BNNPROEntities Init()
        {
            return dbContext ?? (dbContext = new BNNPROEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
