using System;
using Microsoft.EntityFrameworkCore;
using SFCDentalGame.DAL.Entities;
using SFCDentalGame.Models;
namespace SFCDentalGame.DAL
{
    public class SFCContext : DbContext
    {
        public SFCContext(DbContextOptions<SFCContext> options) : base(options)
        {
        }
        public DbSet<Behaviour> Behaviours { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DentalPracticeItem> PracticeItems { get; set; }
        public DbSet<DentalHealth> DentalHealth { get; set; }
        public DbSet<DentalHealthDetail> DentalHealthDetails { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Behaviour>().ToTable("Behaviour");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<DentalPracticeItem>().ToTable("PracticeItem");
            modelBuilder.Entity<DentalHealth>().ToTable("DentalHealth");
            modelBuilder.Entity<DentalHealthDetail>().ToTable("HealthDetail");
            modelBuilder.Entity<Player>().ToTable("Player");
        }
    }
}
