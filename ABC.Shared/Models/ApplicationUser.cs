﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABC.Shared.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string Name {  get; set; }

        public string? StreetName {  get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Barangay { get; set; }
        public string? PostalCode { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}
