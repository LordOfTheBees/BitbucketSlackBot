﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Data.Context
{
    public class BitbucketSlackDataContext : DbContext
    {

        public DbSet<SlackTeam> SlackTeams { get; set; }
        public DbSet<SlackUser> SlackUsers { get; set; }
        public DbSet<BitbucketRepository> Repositories { get; set; }

        public DbSet<SlackUserRepositoryAccess> RepositoryAccesses { get; set; }
        public DbSet<Subscriber> Subscriptions { get; set; }


        public BitbucketSlackDataContext(DbContextOptions<BitbucketSlackDataContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SlackTeam>().ToTable("SlackTeam");
            modelBuilder.Entity<SlackUser>().ToTable("SlackUser");

            modelBuilder.Entity<BitbucketRepository>().ToTable("BitbucketRepository");
            modelBuilder.Entity<SlackUserRepositoryAccess>().ToTable("SlackUserRepositoryAccess");
            modelBuilder.Entity<Subscriber>().ToTable("Subscriber");


            modelBuilder.Entity<SlackUser>().HasKey(c => new { c.SlackUserID, c.SlackTeamID });
            modelBuilder.Entity<BitbucketRepository>().HasKey(c => new { c.BitbucketRepositoryUUID, c.SlackTeamID });
            modelBuilder.Entity<SlackUserRepositoryAccess>().HasKey(c => new { c.SlackUserID, c.SlackTeamID, c.BitbucketRepositoryID });
            modelBuilder.Entity<Subscriber>().HasKey(c => new { c.SlackUserID, c.SlackTeamID, c.BitbucketRepositoryID });

            //two primary composite keys as two foreing keys
            modelBuilder.Entity<SlackUser>()
                .HasMany<SlackUserRepositoryAccess>(elem => elem.RepositoryAccesses)
                .WithOne(repoAccess => repoAccess.SlackUser)
                .HasForeignKey(repoAccess => new { repoAccess.SlackUserID, repoAccess.SlackTeamID });
            modelBuilder.Entity<SlackUser>()
                .HasMany<Subscriber>(elem => elem.Subscriptions)
                .WithOne(subscr => subscr.SlackUser)
                .HasForeignKey(subscr => new { subscr.SlackUserID, subscr.SlackTeamID });

            modelBuilder.Entity<BitbucketRepository>()
                .HasMany<SlackUserRepositoryAccess>(elem => elem.RepositoryAccesses)
                .WithOne(repoAccess => repoAccess.BitbucketRepository)
                .HasForeignKey(repoAccess => new { repoAccess.BitbucketRepositoryID, repoAccess.BitbucketSlackTeamID });
            modelBuilder.Entity<BitbucketRepository>()
                .HasMany<Subscriber>(elem => elem.Subscribers)
                .WithOne(subscr => subscr.BitbucketRepository)
                .HasForeignKey(subscr => new { subscr.BitbucketRepositoryID, subscr.BitbucketSlackTeamID });

            modelBuilder.Entity<SlackUserRepositoryAccess>(sura => sura.HasCheckConstraint("SURA_CC_TeamIDMustBeEquals", "[BitbucketSlackTeamID] = [SlackTeamID]"));
            modelBuilder.Entity<Subscriber>(sura => sura.HasCheckConstraint("S_CC_TeamIDMustBeEquals", "[BitbucketSlackTeamID] = [SlackTeamID]"));
            /*
            modelBuilder.Entity<SlackUser>()
               .HasOne(subs => subs.SlackTeam)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);
            /*
            modelBuilder.Entity<Subscriber>()
               .HasOne(subs => subs.SlackUser)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Subscriber>()
               .HasOne(subs => subs.BitbucketRepository)
               .WithMany()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SlackUserRepositoryAccess>()
               .HasOne(access => access.SlackUser)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SlackUserRepositoryAccess>()
               .HasOne(access => access.BitbucketRepository)
               .WithMany()
               .OnDelete(DeleteBehavior.Cascade);*/
        }
    }
}
