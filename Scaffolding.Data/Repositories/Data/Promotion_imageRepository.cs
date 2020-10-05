using Scaffolding.Data.DbInfrastructure;
using Scaffolding.Models;

namespace Scaffolding.Data.Repositories
{
    public interface IPromotion_imageRepository : IRepository<promotion_image>
    { }

    public class Promotion_imageRepository : RepositoryBase<promotion_image>, IPromotion_imageRepository
    {
        private readonly IDbHelper _dbHelper;

        public Promotion_imageRepository(IDbFactory dbFactory, IDbHelper dbHelper)
            : base(dbFactory) { this._dbHelper = dbHelper; }
    }
}
