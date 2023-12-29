using MongoDB.Driver;
using Proman.DataAccessLayer.Abstract;
using Proman.DataAccessLayer.Repository.Concrete;
using Proman.DataAccessLayer.Settings.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Concrete
{
    public class ProjectDAL : MongoGenericRepository<Project>, IProjectDAL
    {
        private readonly IMongoCollection<Project> _collection;

        public ProjectDAL(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Project>(typeof(Project).Name.ToLowerInvariant());
        }

        public void ChangeProjectStatus(string id)
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

        public List<Project> GetActiveProjects()
        {
            return _collection.Find(x => x.Status == true).SortByDescending(x => x.CreatedAt).ToList();
        }

        public List<Project> GetLast6ActiveProjects()
        {
            var skillCount = _collection.Find(x => x.Status == true && x.IsHome == true).SortByDescending(x => x.CreatedAt).Count();
            var values = _collection.Find(x => x.Status == true && x.IsHome == true).SortByDescending(x => x.CreatedAt).ToList();
            if (skillCount <= 6)
            {
                values = _collection.Find(x => x.Status == true && x.IsHome == true).SortByDescending(x => x.CreatedAt).ToList();
            }
            else
            {
                values = _collection.Find(x => x.Status == true && x.IsHome == true).SortByDescending(x => x.CreatedAt).Limit(6).ToList();
            }
            return values;
        }
    }
}