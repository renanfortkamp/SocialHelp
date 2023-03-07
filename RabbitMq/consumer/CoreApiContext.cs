using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consumer.Models;
using Microsoft.EntityFrameworkCore;


namespace Consumer.Models;
public class CoreApiContext : DbContext
    {


        public DbSet<Message> DbSetMessages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP\\SQLEXPRESS;Database=SocialDb;Trusted_Connection=True;TrustServerCertificate=True;persist security info=True;");
        }
    }

