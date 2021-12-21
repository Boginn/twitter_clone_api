using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPI.Models;

namespace TwitterCloneAPI.Data
{
    public class TwitterDatabaseContext : DbContext
    {
        public DbSet<User> Users{ get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Reply> Replies{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TwitterDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Reply>().Property(e => e.UserId).IsRequired();
        }
    }
}
