﻿namespace Proman.WebUI.DTOs.ServiceDTOs
{
    public class CreateServiceDTO
    {
        public string? ServiceTitle { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ServiceIcon { get; set; }
        public decimal ServicePrice { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}