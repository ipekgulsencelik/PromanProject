namespace Proman.DTO.DTOs.MessageDTOs
{
    public class UpdateMessageDTO
    {
        public string ID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}