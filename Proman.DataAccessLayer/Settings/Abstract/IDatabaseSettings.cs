namespace Proman.DataAccessLayer.Settings.Abstract
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string AboutCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string EducationCollectionName { get; set; }
        public string ExperiienceCollectionName { get; set; }
        public string MapCollectionName { get; set; }
        public string MessageCollectionName { get; set; }
        public string MyProfileCollectionName { get; set; }
        public string ProjectCollectionName { get; set; }
        public string ProjectTypeCollectionName { get; set; }
        public string ServiceCollectionName { get; set; }
        public string SkillCollectionName { get; set; }
        public string SocialMediaCollectionName { get; set; }
        public string TeamCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
    }
}