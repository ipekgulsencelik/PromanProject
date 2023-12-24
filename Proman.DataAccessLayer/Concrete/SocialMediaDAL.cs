using MongoDB.Driver;
using Proman.DataAccessLayer.Abstract;
using Proman.DataAccessLayer.Repository.Concrete;
using Proman.DataAccessLayer.Settings.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Concrete
{
    public class SocialMediaDAL : MongoGenericRepository<SocialMedia>, ISocialMediaDAL
    {
        private readonly IMongoCollection<SocialMedia> _collection;

        public SocialMediaDAL(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<SocialMedia>(typeof(SocialMedia).Name.ToLowerInvariant());
        }

        public void ChangeSocialMediaStatus(string id)
        {
            var value = _collection.Find(x => x.ID == id).FirstOrDefault();
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            _collection.FindOneAndReplace(x => x.ID == value.ID, value);
        }

        public void ChangeHomeStatus(string id)
        {
            var value = _collection.Find(x => x.ID == id).FirstOrDefault();
            if (value.IsHome == true)
            {
                value.IsHome = false;
            }
            else
            {
                value.IsHome = true;
            }
            _collection.FindOneAndReplace(x => x.ID == value.ID, value);
        }

        public List<SocialMedia> GetLast4ActiveSocialMedias()
        {
            var accountCount = _collection.Find(x => x.Status == true && x.IsHome == true).SortByDescending(x => x.CreatedAt).Count();
            var values = _collection.Find(x => x.Status == true && x.IsHome == true).SortByDescending(x => x.CreatedAt).ToList();
            if (accountCount <= 4)
            {
                values = _collection.Find(x => x.Status == true && x.IsHome == true).SortByDescending(x => x.CreatedAt).ToList();
            }
            else
            {
                values = _collection.Find(x => x.Status == true && x.IsHome == true).SortByDescending(x => x.CreatedAt).Limit(4).ToList();
            }
            return values;
        }
    }
}