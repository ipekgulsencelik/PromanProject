namespace Proman.WebUI.DTOs.SkillDTOs
{
    public class CreateSkillDTO
    {
        public string? SkillName { get; set; }
        public int SkillScore { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}