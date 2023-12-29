using Proman.DataAccessLayer.Repository.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Abstract
{
    public interface IAboutDAL : IMongoGenericRepository<About>
    {
        void ChangeAboutStatus(string id);
        void ChangeHomeStatus(string id);
        List<Experience> GetLast4ActiveExperiences();
        List<Experience> GetActiveExperiences();
    }
}
