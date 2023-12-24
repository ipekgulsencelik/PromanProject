namespace Proman.DTO.DTOs.SocialMediaDTOs
{
    public class CreateSocialMediaDTO
    {
        public string? SocialMediaIcon { get; set; }
        public string? SocialMediaURL { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}