namespace Proman.DTO.DTOs.AboutDTOs
{
    public class CreateAboutDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}
