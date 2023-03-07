using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer.Models
{
    public class MessagePublish
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int GroupId { get; set; }
    }
}