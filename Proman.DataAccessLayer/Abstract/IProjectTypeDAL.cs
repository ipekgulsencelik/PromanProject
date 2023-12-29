using Proman.DataAccessLayer.Repository.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Abstract
{
    public interface IProjectTypeDAL : IMongoGenericRepository<ProjectType>
    {
        void ChangeProjectTypeStatus(string id);
        void ChangeHomeStatus(string id);
        ProjectType GetProjectTypeWithProducts(string id);
        List<ProjectType> GetAllProjectTypeWithProducts();        
        List<ProjectType> GetLast2ActiveProjectTypes();
        List<ProjectType> GetActiveProjectTypes();
    }
}