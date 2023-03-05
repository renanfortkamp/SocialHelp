using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialHelpApi.Models.Entities;

namespace SocialHelpApi.Context
{
    public class ContextApi : DbContext
    {
        public ContextApi(DbContextOptions<ContextApi> options) : base(options)
        {

        }
            public DbSet<User> DbSetUsers { get; set; }
            public DbSet<Message> DbSetMessages { get; set; }
            public DbSet<Group> DbSetGroups { get; set; }

        
    }
}