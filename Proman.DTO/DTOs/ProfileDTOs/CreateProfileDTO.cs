﻿namespace Proman.DTO.DTOs.ProfileDTOs
{
    public class CreateProfileDTO
    {
        public string FullName { get; set; }
        public string Title { get; set; }
        public string? CV { get; set; }
        public string? VideoURL { get; set; }
        public string? ImageURL { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}
