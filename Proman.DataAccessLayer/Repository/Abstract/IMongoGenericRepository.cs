using Proman.EntityLayer.Abstract;

namespace Proman.DataAccessLayer.Repository.Abstract
{
    public interface IMongoGenericRepository<T> where T : IMongoBaseEntity
    {
        List<T> GetAll();
        T GetByID(string id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(string id);
    }
}