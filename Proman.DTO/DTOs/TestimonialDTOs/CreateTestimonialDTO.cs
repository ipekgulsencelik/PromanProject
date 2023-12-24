namespace Proman.DTO.DTOs.TestimonialDTOs
{
    public class CreateTestimonialDTO
    {
        public string? TestimonialFullName { get; set; }
        public string? TestimonialComment { get; set; }
        public string? TestimonialImageURL { get; set; }
        public string? TestimonialTitle { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}