namespace Proman.DTO.DTOs.MapDTOs
{
    public class UpdateMapDTO
    {
        public string ID { get; set; }
        public string? MapURL { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}