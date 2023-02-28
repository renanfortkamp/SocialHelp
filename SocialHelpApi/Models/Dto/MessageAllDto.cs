using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SocialHelpApi.Models.Dto
{
    public class MessageAllDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Text { get; set; }
        public string DataPostagem { get; set; }
        public int EnumStatus { get; set; }
        public bool Editado { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

    }
}
