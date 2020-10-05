using Scaffolding.Data.DbInfrastructure;
using Scaffolding.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace Scaffolding.Data.Repositories
{
    public interface ICategoryRepository : IRepositoryBase<category>
    {

    }

    public class CategoryRepository : RepositoryBase<category>, ICategoryRepository
    {
        private readonly IDBHelper _dbHelper;

        public CategoryRepository(DBEntities dbContext, IDBHelper dbHelper)
            : base(dbContext) { this._dbHelper = dbHelper; }

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
