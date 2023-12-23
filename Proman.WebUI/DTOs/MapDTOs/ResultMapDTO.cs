namespace Proman.WebUI.DTOs.MapDTOs
{
    public class ResultMapDTO
    {
        public string ID { get; set; }
        public string? MapURL { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}