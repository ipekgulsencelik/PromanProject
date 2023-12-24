using MongoDB.Driver;
using Proman.DataAccessLayer.Abstract;
using Proman.DataAccessLayer.Repository.Concrete;
using Proman.DataAccessLayer.Settings.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Concrete
{
    public class EducationDAL : MongoGenericRepository<Education>, IEducationDAL
    {
        private readonly IMongoCollection<Education> _collection;

        public EducationDAL(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Education>(typeof(Education).Name.ToLowerInvariant());
        }

        public void ChangeEducationStatus(string id)
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

        public List<Education> GetActiveEducations()
        {
            return _collection.Find(x => x.Status == true).SortByDescending(x => x.CreatedAt).ToList();
        }

        public List<Education> GetLast4ActiveEducations()
        {
            var educationCount = _collection.Find(x => x.Status == true && x.IsHome == true).SortByDescending(x => x.CreatedAt).Count();
            var values = _collection.Find(x => x.Status == true && x.IsHome == true).SortByDescending(x => x.CreatedAt).ToList();
            if (educationCount <= 4)
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