﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialHelpApi.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }      

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }  

        [Required]
        public string Role { get; set; } = "User";

        public string Image { get; set; } = null;
        public int GroupId { get; set; } = 1;
        
    }
}
