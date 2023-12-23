using Proman.DataAccessLayer.Repository.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Abstract
{
    public interface IContactDAL : IMongoGenericRepository<Contact>
    {
        void ChangeContactStatus(string id);
        Contact GetActiveContact();
    }
}