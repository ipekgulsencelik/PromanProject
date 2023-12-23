using Proman.EntityLayer.Abstract;

namespace Proman.EntityLayer.Concrete
{
    public class SocialMedia : IMongoBaseEntity
    {
        public string? SocialMediaIcon { get; set; }
        public string? SocialMediaURL { get; set; }
        public bool IsHome { get; set; }
    }
}