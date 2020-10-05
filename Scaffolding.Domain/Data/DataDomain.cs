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
        private readonly IPromotion_imageRepository _promotionImageRepository;
        private readonly IProductRepository _productRepository;
        #endregion [Private Members]

        #region [Constructor]
        public DataDomain(
                IEFUnitOfWork efUnitOfWork,
                ICategoryRepository categoryRepository,
                IPromotion_imageRepository promotionImageRepository,
                IProductRepository productRepository
            )
        {
            this._efUnitOfWork = efUnitOfWork;
            this._categoryRepository = categoryRepository;
            this._promotionImageRepository = promotionImageRepository;
            this._productRepository = productRepository;
        }
        #endregion [Constructor]

        public void Save()
        {
            this._efUnitOfWork.Commit();
        }
    }
}
