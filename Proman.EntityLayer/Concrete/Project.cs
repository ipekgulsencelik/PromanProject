using Proman.EntityLayer.Abstract;

namespace Proman.EntityLayer.Concrete
{
    public class Project : IMongoBaseEntity
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ImageURL { get; set; }
        public string ProjectLink { get; set; }
        public bool IsHome { get; set; }

        public ProjectType ProjectType { get; set; }
    }
}