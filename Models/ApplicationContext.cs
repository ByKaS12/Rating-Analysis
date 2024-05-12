using DiplomMag.models;
using Microsoft.EntityFrameworkCore;



namespace DiplomMag.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        public ApplicationContext()
        {
            _ = Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RatingAnalysis;Trusted_Connection=True;");
            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);

            _ = optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite($"Data Source={path}{Path.DirectorySeparatorChar}Rating-analysis.db");
        }
    }
}