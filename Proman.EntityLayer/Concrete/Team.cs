using Proman.EntityLayer.Abstract;

namespace Proman.EntityLayer.Concrete
{
    public class Team : IMongoBaseEntity
    {
        public string? TeamFullName { get; set; }
        public string? TeamImageURL { get; set; }
        public string? TeamTitle { get; set; }
        public bool IsHome { get; set; }
    }
}