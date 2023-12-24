using Proman.EntityLayer.Abstract;

namespace Proman.EntityLayer.Concrete
{
    public class Education : IMongoBaseEntity
    {
        public string? EducationName { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public string? SchoolName { get; set; }
        public bool IsHome { get; set; }
    }
}