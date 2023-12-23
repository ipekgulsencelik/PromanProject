using Proman.DataAccessLayer.Repository.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Abstract
{
    public interface IMessageDAL : IMongoGenericRepository<Message>
    {
        void ChangeMessageStatus(string id);
    }
}