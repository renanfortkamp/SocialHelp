using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SocialHelpApi.Models.Dto
{
    public class MessageAllDto
    {
        [Required]
        [StringLength(255)]
        public string Text { get; set; }
        public string DateMessage { get; set; }
        public int EnumStatus { get; set; } = 1;
        public bool Edit { get; set; } = false;

        [ForeignKey("User")]
        public int UserId { get; set; }


    }
}
