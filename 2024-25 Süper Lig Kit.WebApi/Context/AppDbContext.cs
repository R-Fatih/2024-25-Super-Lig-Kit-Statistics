using _2024_25_Süper_Lig_Kit.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace _2024_25_Süper_Lig_Kit.WebApi.Context
{
    public class AppDbContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasOne(x=>x.HomeTeam).WithMany(y=>y.HomeMatches).HasForeignKey(z=>z.HomeTeamId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Match>().HasOne(x=>x.AwayTeam).WithMany(y=>y.AwayMatches).HasForeignKey(z=>z.AwayTeamId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Match>().HasOne(x=>x.HomeTeamJerseyImage).WithMany(y=>y.HomeTeamJerseyImageMatches).HasForeignKey(z=>z.HomeTeamJerseyImageId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Match>().HasOne(x=>x.AwayTeamJerseyImage).WithMany(y=>y.AwayTeamJerseyImageMatches).HasForeignKey(z=>z.AwayTeamJerseyImageId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Match>().HasOne(x=>x.RefereeJerseyImage).WithMany(y=>y.RefereeJerseyImageMatches).HasForeignKey(z=>z.RefereeJerseyImageId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Match>().HasOne(x=>x.HomeTeamJerseyImageGK).WithMany(y=>y.HomeTeamJerseyImageGKMatches).HasForeignKey(z=>z.HomeTeamJerseyImageGKId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Match>().HasOne(x=>x.AwayTeamJerseyImageGK).WithMany(y=>y.AwayTeamJerseyImageGKMatches).HasForeignKey(z=>z.AwayTeamJerseyImageGKId).OnDelete(DeleteBehavior.ClientSetNull);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=2425SL;Trusted_Connection=True;MultipleActiveResultSets=true;Connect Timeout=0;");

        }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<JerseyImage> JerseyImages { get; set; }
        public DbSet<Jersey> Jerseys { get; set; }

    }
}
