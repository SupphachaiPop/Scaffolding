using Scaffolding.Data;
using Scaffolding.Data.DbInfrastructure;
using Scaffolding.Data.Repositories;

namespace Scaffolding.Domain
{
    public partial interface IDataDomain
    {
        // Commit Transaction of DataDomain
        void Save();
    }

    // Implement Repository
    public partial class DataDomain : IDataDomain
    {
        #region [Private Members]
        private readonly IEFUnitOfWork _efUnitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        #endregion [Private Members]

        #region [Constructor]
        public DataDomain(
                IEFUnitOfWork efUnitOfWork,
                ICategoryRepository categoryRepository
            )
        {
            this._efUnitOfWork = efUnitOfWork;
            this._categoryRepository = categoryRepository;
        }
        #endregion [Constructor]

        public void Save()
        {
            this._efUnitOfWork.Commit();
        }

        public void SaveAsync()
        {
            this._efUnitOfWork.CommitAsync();
        }
    }
}
