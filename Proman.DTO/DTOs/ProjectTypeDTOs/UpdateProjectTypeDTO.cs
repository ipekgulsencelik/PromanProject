namespace Proman.DTO.DTOs.ProjectTypeDTOs
{
    public class UpdateProjectTypeDTO
    {
        public string ID { get; set; }
        public string ProjectTypeName { get; set; }
        public string ProjectTypeDescription { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}