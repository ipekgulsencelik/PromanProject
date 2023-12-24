using Proman.DataAccessLayer.Repository.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Abstract
{
    public interface IEducationDAL : IMongoGenericRepository<Education>
    {
        void ChangeEducationStatus(string id);
        void ChangeHomeStatus(string id);
        List<Education> GetLast4ActiveEducations();
        List<Education> GetActiveEducations();
    }
}