namespace Proman.DTO.DTOs.TeamDTOs
{
    public class UpdateTeamDTO
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