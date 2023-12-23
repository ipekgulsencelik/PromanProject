using MongoDB.Driver;
using Proman.DataAccessLayer.Repository.Abstract;
using Proman.DataAccessLayer.Settings.Abstract;
using Proman.EntityLayer.Abstract;

namespace Proman.DataAccessLayer.Repository.Concrete
{
    public class MongoGenericRepository<T> : IMongoGenericRepository<T> where T : IMongoBaseEntity
    {
        private readonly IMongoCollection<T> collection;

        public MongoGenericRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            collection = database.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }

        public void Delete(string id)
        {
            collection.FindOneAndDelete(x => x.ID == id);
        }

        public List<T> GetAll()
        {
            return collection.AsQueryable().ToList();
        }

        public T GetByID(string id)
        {
            return collection.Find(x => x.ID == id).FirstOrDefault();
        }

        public void Insert(T entity)
        {
            collection.InsertOne(entity);
        }

        public void Update(T entity)
        {
            collection.FindOneAndReplace(x => x.ID == entity.ID, entity);
        }
    }
}