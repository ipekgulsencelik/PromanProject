using Proman.DataAccessLayer.Repository.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Abstract
{
    public interface ITestimonialDAL : IMongoGenericRepository<Testimonial>
    {
        void ChangeTestimonialStatus(string id);
        void ChangeHomeStatus(string id);
        List<Testimonial> GetLast3ActiveTestimonials();
        List<Testimonial> GetActiveTestimonials();
    }
}