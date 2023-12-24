using Proman.EntityLayer.Abstract;

namespace Proman.EntityLayer.Concrete
{
    public class Experience : IMongoBaseEntity
    {
        public string? ExperienceTitle { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public string? CompanyName { get; set; }
        public bool IsHome { get; set; }
    }
}