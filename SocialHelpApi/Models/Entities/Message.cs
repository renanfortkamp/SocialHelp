﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SocialHelpApi.Models.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Text { get; set; }
        public DateTime DateMessage { get; set; } = DateTime.Now;
        public int EnumStatus { get; set; } = 1;
        public bool Edit { get; set; } = false;

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
