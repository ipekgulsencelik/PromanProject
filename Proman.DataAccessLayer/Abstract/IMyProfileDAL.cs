using Proman.DataAccessLayer.Repository.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Abstract
{
    public interface IMyProfileDAL : IMongoGenericRepository<MyProfile>
    {
        void ChangeProfileStatus(string id);
        void ChangeHomeStatus(string id);
        MyProfile GetActiveProfile();
    }
}