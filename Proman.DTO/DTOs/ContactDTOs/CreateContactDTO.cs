﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proman.DTO.DTOs.ContactDTOs
{
    public class CreateContactDTO
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}
