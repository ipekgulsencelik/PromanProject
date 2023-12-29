namespace Proman.DTO.DTOs.ProjectTypeDTOs
{
    public class CreateProjectTypeDTO
    {
        public string ProjectTypeName { get; set; }
        public string ProjectTypeDescription { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}