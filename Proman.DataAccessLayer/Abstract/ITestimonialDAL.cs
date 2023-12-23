using Proman.DataAccessLayer.Repository.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Abstract
{
    public interface ITestimonialDAL : IMongoGenericRepository<Testimonial>
    {
        void ChangeTeamStatus(int id);
        void ChangeHomeStatus(int id);
        List<Testimonial> GetLast3Teams();
        List<Testimonial> GetActiveTeams();
    }
}