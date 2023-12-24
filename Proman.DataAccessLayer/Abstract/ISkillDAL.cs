using Proman.DataAccessLayer.Repository.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Abstract
{
    public interface ISkillDAL : IMongoGenericRepository<Skill>
    {
        void ChangeSkillStatus(string id);
        void ChangeHomeStatus(string id);
        List<Skill> GetLast6ActiveSkills();
        List<Skill> GetActiveSkills();
    }
}