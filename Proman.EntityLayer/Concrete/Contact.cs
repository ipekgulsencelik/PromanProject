using Proman.EntityLayer.Abstract;

namespace Proman.EntityLayer.Concrete
{
    public class Contact : IMongoBaseEntity
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}