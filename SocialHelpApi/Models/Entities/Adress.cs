using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialHelpApi.Models.Entities
{
    public class Adress
    {
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}