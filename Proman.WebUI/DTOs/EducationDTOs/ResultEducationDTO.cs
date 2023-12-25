namespace Proman.WebUI.DTOs.EducationDTOs
{
    public class ResultEducationDTO
    {
        public string ID { get; set; }
        public string? EducationName { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public string? SchoolName { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}
