using Proman.DataAccessLayer.Repository.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Abstract
{
    public interface ISocialMediaDAL : IMongoGenericRepository<SocialMedia>
    {
        void ChangeSocialMediaStatus(string id);
        void ChangeHomeStatus(string id);
        List<SocialMedia> GetLast4ActiveSocialMedias();
    }
}