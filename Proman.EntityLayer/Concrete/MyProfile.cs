using Proman.EntityLayer.Abstract;

namespace Proman.EntityLayer.Concrete
{
    public class MyProfile : IMongoBaseEntity
    {
        public string FullName { get; set; }
        public string Title { get; set; }
        public string? CV { get; set; }
        public string? VideoURL { get; set; }
        public string? ImageURL { get; set; }
        public bool IsHome { get; set; }
    }
}