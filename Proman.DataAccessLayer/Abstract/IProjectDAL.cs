using Proman.DataAccessLayer.Repository.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Abstract
{
    public interface IProjectDAL : IMongoGenericRepository<Project>
    {
        void ChangeProjectStatus(string id);
        void ChangeHomeStatus(string id);
        List<Project> GetLast6ActiveProjects();
        List<Project> GetActiveProjects();
    }
}