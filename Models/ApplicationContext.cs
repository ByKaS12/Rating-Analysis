﻿using DiplomMag.models;
using Microsoft.EntityFrameworkCore;



namespace DiplomMag.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Rebound> Rebounds { get; set; }
        public DbSet<Shoot> Shoots { get; set; }

        public ApplicationContext()
        {
            _ = Database.EnsureCreated();
        }
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=rating-analysis;Trusted_Connection=True;");
		//}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RatingAnalysis;Trusted_Connection=True;");
			Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
			string path = Environment.GetFolderPath(folder);

			_ = optionsBuilder
				.UseSqlite($"Data Source={path}{Path.DirectorySeparatorChar}Rating-analysis.db");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Statistic>()
		   .HasOne(e => e.Shoots)
		   .WithOne()
		   .HasForeignKey<Shoot>(e => e.StatisticId);

			modelBuilder.Entity<Statistic>()
		   .HasOne(e => e.Rebounds)
		   .WithOne()
		   .HasForeignKey<Rebound>(e => e.StatisticId);

			modelBuilder.Entity<Statistic>().Ignore(e => e._points);
			modelBuilder.Entity<Rebound>().Ignore(e => e._AllReb);
			modelBuilder.Entity<Shoot>().Ignore(e => e._FieldGoalsAllPoints);
			modelBuilder.Entity<Shoot>().Ignore(e => e._FieldGoalsScoredPoints);


			//modelBuilder.Entity<Statistic>().ToTable("Statistics");
			//modelBuilder.Entity<Shoot>().ToTable("Statistics");
			//modelBuilder.Entity<Rebound>().ToTable("Statistics");
		}
	}
}