using System;
using Microsoft.EntityFrameworkCore;
using SFCDentalGame.DAL.Entities;
using SFCDentalGame.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SFCDentalGame.DAL
{
    public class SFCContext : IdentityDbContext<IdentityUser>
    {
        public SFCContext(DbContextOptions<SFCContext> options) : base(options)
        {
        }
        public DbSet<Behaviour> Behaviours { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DentalPracticeItem> PracticeItems { get; set; }
        public DbSet<DentalHealth> DentalHealth { get; set; }
        public DbSet<DentalHealthDetail> DentalHealthDetails { get; set; }
        public DbSet<Frequency> Frequency { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<FreqBehaviour> FrequencyBehaviours { get; set; }
        public DbSet<RangeBehaviour> RangeBehaviours { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Behaviour>().ToTable("Behaviour");
            builder.Entity<Category>().ToTable("Category");
            builder.Entity<DentalPracticeItem>().ToTable("PracticeItem");
            builder.Entity<DentalHealth>().ToTable("DentalHealth");
            builder.Entity<DentalHealthDetail>().ToTable("HealthDetail");
            builder.Entity<Player>().ToTable("Player");
            builder.Entity<Frequency>().ToTable("Frequency");
            builder.Entity<Profile>().ToTable("Profile");
            builder.Entity<FreqBehaviour>().ToTable("FrequencyBehaviour");
            builder.Entity<RangeBehaviour>().ToTable("RangeBehaviour");
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserRole<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityUser<string>>();
        }
    }
}
