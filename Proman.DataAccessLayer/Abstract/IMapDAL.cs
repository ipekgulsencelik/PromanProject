using Proman.DataAccessLayer.Repository.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Abstract
{
    public interface IMapDAL : IMongoGenericRepository<Map>
    {
        void ChangeMapStatus(string id);
        Map GetActiveMap();
    }
}