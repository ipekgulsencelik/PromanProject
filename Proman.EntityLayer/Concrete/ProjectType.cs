using Proman.EntityLayer.Abstract;

namespace Proman.EntityLayer.Concrete
{
    public class ProjectType : IMongoBaseEntity
    {
        public string ProjectTypeName { get; set; }
        public string ProjectTypeDescription { get; set; }
        public bool IsHome { get; set; }

        //public List<Project>? Projects { get; set; }
    }
}