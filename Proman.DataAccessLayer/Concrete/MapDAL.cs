using MongoDB.Driver;
using Proman.DataAccessLayer.Abstract;
using Proman.DataAccessLayer.Repository.Concrete;
using Proman.DataAccessLayer.Settings.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Concrete
{
    public class MapDAL : MongoGenericRepository<Map>, IMapDAL
    {
        private readonly IMongoCollection<Map> _collection;

        public MapDAL(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Map>(typeof(Map).Name.ToLowerInvariant());
        }

        public void ChangeMapStatus(string id)
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

        public Map GetActiveMap()
        {
            return _collection.Find(x => x.Status == true).SortByDescending(x => x.CreatedAt).FirstOrDefault();
        }
    }
}