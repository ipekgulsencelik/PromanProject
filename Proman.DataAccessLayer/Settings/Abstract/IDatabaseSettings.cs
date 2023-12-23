namespace Proman.DataAccessLayer.Settings.Abstract
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string ContactCollectionName { get; set; }
        public string MapCollectionName { get; set; }
        public string MessageCollectionName { get; set; }
        public string ServiceCollectionName { get; set; }
        public string SocialMediaCollectionName { get; set; }
        public string TeamCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
    }
}