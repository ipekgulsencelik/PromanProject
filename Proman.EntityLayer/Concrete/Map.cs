using Proman.EntityLayer.Abstract;

namespace Proman.EntityLayer.Concrete
{
    public class Map : IMongoBaseEntity
    {
        public string? MapURL { get; set; }
    }
}