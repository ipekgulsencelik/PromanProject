namespace Proman.WebUI.DTOs.SocialMediaDTOs
{
    public class ResultSocialMediaDTO
    {
        public string ID { get; set; }
        public string? SocialMediaIcon { get; set; }
        public string? SocialMediaURL { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}