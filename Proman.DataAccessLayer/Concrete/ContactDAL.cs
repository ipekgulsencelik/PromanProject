using MongoDB.Driver;
using Proman.DataAccessLayer.Abstract;
using Proman.DataAccessLayer.Repository.Concrete;
using Proman.DataAccessLayer.Settings.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Concrete
{
	public class ContactDAL : MongoGenericRepository<Contact>, IContactDAL
    {
        private readonly IMongoCollection<Contact> _collection;

        public ContactDAL(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Contact>(typeof(Contact).Name.ToLowerInvariant());
        }

        public void ChangeContactStatus(string id)
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

        public Contact GetActiveContact()
        {
            return _collection.Find(x => x.Status == true).SortByDescending(x => x.CreatedAt).FirstOrDefault();
        }
    }
}
