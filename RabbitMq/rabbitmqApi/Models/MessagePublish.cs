using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rabbitmqApi.Models
{
    public class MessagePublish
    {
        public string Text { get; set; }
        public int UserId { get; set; }
    }
}