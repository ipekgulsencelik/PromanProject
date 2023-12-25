namespace Proman.WebUI.DTOs.TeamDTOs
{
    public class ResultTeamDTO
    {
        public string ID { get; set; }
        public string? TeamFullName { get; set; }
        public string? TeamImageURL { get; set; }
        public string? TeamTitle { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}