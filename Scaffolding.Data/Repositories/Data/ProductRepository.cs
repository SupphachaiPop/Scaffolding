using Scaffolding.Data.DbInfrastructure;
using Scaffolding.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Scaffolding.Data.Repositories
{
    public interface IProductRepository : IRepository<product>
    {

    }

    public class ProductRepository : RepositoryBase<product>, IProductRepository
    {
        private readonly IDbHelper _dbHelper;

        public ProductRepository(IDbFactory dbFactory, IDbHelper dbHelper)
            : base(dbFactory) { this._dbHelper = dbHelper; }

    }
}
