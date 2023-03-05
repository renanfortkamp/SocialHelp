using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SocialHelpApi.Models.Dto
{
    public class MessageAllDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string DateMessage { get; set; }
        public int EnumStatus { get; set; } = 1;
        public bool Edit { get; set; } = false;
        public int UserId { get; set; }
        public string UserName { get; set; }


    }
}
