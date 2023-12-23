using Proman.EntityLayer.Abstract;

namespace Proman.EntityLayer.Concrete
{
    public class Message : IMongoBaseEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}