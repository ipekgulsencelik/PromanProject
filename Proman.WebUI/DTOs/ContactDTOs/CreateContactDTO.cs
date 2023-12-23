namespace Proman.WebUI.DTOs.ContactDTOs
{
    public class CreateContactDTO
    {
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}