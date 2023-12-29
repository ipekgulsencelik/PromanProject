using Proman.EntityLayer.Abstract;

namespace Proman.EntityLayer.Concrete
{
    public class About : IMongoBaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsHome { get; set; }
    }
}
