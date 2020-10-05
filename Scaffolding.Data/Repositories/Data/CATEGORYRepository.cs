using Scaffolding.Data.DbInfrastructure;
using Scaffolding.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace Scaffolding.Data.Repositories
{
    public interface ICategoryRepository : IRepository<category>
    {

    }

    public class CategoryRepository : RepositoryBase<category>, ICategoryRepository
    {
        private readonly IDbHelper _dbHelper;

        public CategoryRepository(IDbFactory dbFactory, IDbHelper dbHelper)
            : base(dbFactory) { this._dbHelper = dbHelper; }

        //public IEnumerable<SELECT_CATEGORY_LIST> GetCategoryList(int? refCategoryId)
        //{
        //    var pParentRefCategoryId = new SqlParameter("REF_CATEGORY_ID", this._dbHelper.CheckNull(refCategoryId));

        //    return this.DbContext.Database.SqlQuery<SELECT_CATEGORY_LIST>
        //        ("exec dbo.SELECT_CATEGORY_LIST @REF_CATEGORY_ID;",
        //                                               pParentRefCategoryId
        //    ).ToList();
        //}
    }
}
