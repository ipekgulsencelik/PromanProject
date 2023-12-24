using Proman.EntityLayer.Abstract;

namespace Proman.EntityLayer.Concrete
{
    public class Skill : IMongoBaseEntity
    {
        public string? SkillName { get; set; }
        public int SkillScore { get; set; }
        public bool IsHome { get; set; }
    }
}