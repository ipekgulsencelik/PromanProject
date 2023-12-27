using MongoDB.Driver;
using Proman.DataAccessLayer.Abstract;
using Proman.DataAccessLayer.Repository.Concrete;
using Proman.DataAccessLayer.Settings.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Concrete
{
    public class TestimonialDAL : MongoGenericRepository<Testimonial>, ITestimonialDAL
    {
        private readonly IMongoCollection<Testimonial> _collection;

        public TestimonialDAL(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Testimonial>(typeof(Testimonial).Name.ToLowerInvariant());
        }

        public void ChangeTestimonialStatus(string id)
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

        public List<Testimonial> GetActiveTestimonials()
        {
            return _collection.Find(x => x.Status == true).SortByDescending(x => x.CreatedAt).ToList();
        }

        public List<Testimonial> GetLast3ActiveTestimonials()
        {
            var testimonialCount = _collection.Find(x => x.Status == true && x.IsHome == true).SortByDescending(x => x.CreatedAt).Count();
            var values = _collection.Find(x => x.Status == true && x.IsHome == true).SortByDescending(x => x.CreatedAt).ToList();
            if (testimonialCount <= 3)
            {
                values = _collection.Find(x => x.Status == true && x.IsHome == true).SortByDescending(x => x.CreatedAt).ToList();
            }
            else
            {
                values = _collection.Find(x => x.Status == true && x.IsHome == true).SortByDescending(x => x.CreatedAt).Limit(3).ToList();
            }
            return values;
        }

        public Testimonial GetTestimonialByID(string id)
        {
            var value = _collection.Find(x => x.ID == id).FirstOrDefault();
            return value;
        }
    }
}