using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialHelpApi.Models.Dto
{
    public class GroupDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; } = null;
        public int UserId { get; set; }
    }
}