using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Data.Context
{
    public class BitbucketSlackDataContext : DbContext
    {
        public BitbucketSlackDataContext(DbContextOptions<BitbucketSlackDataContext> options) : base(options)
        {
        }

        public DbSet<SlackWorkspace> SlackWorkspaces { get; set; }
        public DbSet<SlackUser> SlackUsers { get; set; }
        public DbSet<BitbucketRepository> Repositories { get; set; }

        public DbSet<SlackUserWorkspaceSettings> UserWorkspaceSettings { get; set; }
        public DbSet<SlackUserRepositoryAccess> RepositoryAccesses { get; set; }
        public DbSet<Subscriber> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SlackWorkspace>().ToTable("SlackWorkspace");
            modelBuilder.Entity<SlackUser>().ToTable("SlackUser");
            modelBuilder.Entity<SlackUserWorkspaceSettings>().ToTable("SlackUserWorkspaceSettings");

            modelBuilder.Entity<BitbucketRepository>().ToTable("BitbucketRepository");
            modelBuilder.Entity<SlackUserRepositoryAccess>().ToTable("SlackUserRepositoryAccess");
            modelBuilder.Entity<Subscriber>().ToTable("Subscriber");


            modelBuilder.Entity<SlackUserWorkspaceSettings>().HasKey(c => new { c.SlackUserID, c.SlackWorkspaceID });
            modelBuilder.Entity<SlackUserRepositoryAccess>().HasKey(c => new { c.SlackUserID, c.BitbucketRepositoryID });
            modelBuilder.Entity<Subscriber>().HasKey(c => new { c.SlackUserID, c.BitbucketRepositoryID });

            /*
            modelBuilder.Entity<BitbucketRepository>()
               .HasOne(repo => repo.Author)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);
            /*
            modelBuilder.Entity<Subscriber>()
               .HasOne(subs => subs.SlackUser)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SlackUserRepositoryAccess>()
               .HasOne(access => access.SlackUser)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);*/
        }
    }
}
