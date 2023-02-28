using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SocialHelpApi.Models.Dto
{
    public class MessageDto
    {

        [Required]
        [StringLength(255)]
        public string Text { get; set; }

    }
}
