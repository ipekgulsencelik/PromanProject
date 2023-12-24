using Proman.DataAccessLayer.Repository.Abstract;
using Proman.EntityLayer.Concrete;

namespace Proman.DataAccessLayer.Abstract
{
    public interface ITeamDAL : IMongoGenericRepository<Team>
    {
        void ChangeTeamStatus(string id);
        void ChangeHomeStatus(string id);
        List<Team> GetLast3ActiveTeams();
        List<Team> GetActiveTeams();
    }
}
