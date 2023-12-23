using Proman.DataAccessLayer.Repository.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Abstract
{
    public interface IServiceDAL : IMongoGenericRepository<Service>
    {
        void ChangeServiceStatus(string id);
        void ChangeHomeStatus(string id);
        List<Service> GetLast4Services();
        List<Service> GetActiveServices();
    }
}