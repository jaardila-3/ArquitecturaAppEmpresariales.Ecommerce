﻿using System.ComponentModel.DataAnnotations;

namespace ArquitecturaAppEmpresariales.Ecommerce.Application.DTO
{
    public class CustomersDto
    {
        [Required]
        public string CustomerId { get; set; } = string.Empty;
        [Required]
        public string CompanyName { get; set; } = string.Empty;
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
    }
}