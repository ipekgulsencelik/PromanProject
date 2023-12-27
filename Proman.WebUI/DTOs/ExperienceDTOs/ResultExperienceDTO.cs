﻿namespace Proman.WebUI.DTOs.ExperienceDTOs
{
    public class ResultExperienceDTO
    {
        public string ID { get; set; }
        public string? ExperienceTitle { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public string? CompanyName { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}