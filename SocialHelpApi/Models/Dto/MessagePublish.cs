using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialHelpApi.Models.Dto
{
    public class MessagePublish
    {
        public string Text { get; set; }
        public int UserId { get; set; }
    }
}