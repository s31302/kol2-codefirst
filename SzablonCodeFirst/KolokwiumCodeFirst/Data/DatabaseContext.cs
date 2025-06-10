using KolokwiumCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumCodeFirst.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    

    public DbSet<Match> Matches { get; set; }
    public DbSet<Map> Maps { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Player_Match> PlayerMatches { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Map>().HasData(new List<Map>
        {
            new Map { MapId = 1,  Name = "Inferno", Type = "a"},
            new Map { MapId = 2,  Name = "Mirage" ,Type = "b"},
            new Map { MapId = 3,  Name = "Map", Type = "a"}
        });

        modelBuilder.Entity<Tournament>().HasData(new List<Tournament>
        {
            new Tournament { TournamentId = 1, Name = "CS2 Summer Cup", StartDate = DateTime.Parse("2025-07-02T15:00:00"), EndDate = DateTime.Parse("2025-08-02T15:00:00") },
            new Tournament { TournamentId = 2, Name = "CS2 Summer Cup", StartDate = DateTime.Parse("2025-03-02T15:00:00"), EndDate = DateTime.Parse("2025-09-02T15:00:00") },
            new Tournament { TournamentId = 3, Name = "CS2 Summer Cup",StartDate = DateTime.Parse("2025-04-02T15:00:00"), EndDate = DateTime.Parse("2025-10-02T15:00:00") }
        });

        modelBuilder.Entity<Player>().HasData(new List<Player>
        {
            new Player { PlayerId = 1, FirstName = "Alex", LastName = "Nowak", BirthDate = DateTime.Parse("2005-01-02T15:00:00") },
            new Player { PlayerId = 2, FirstName = "Piotr", LastName = "Smith", BirthDate = DateTime.Parse("2015-07-02T15:00:00") },
            new Player { PlayerId = 3, FirstName = "Zofia", LastName = "Cocos", BirthDate = DateTime.Parse("2004-02-02T15:00:00") }
        });

        modelBuilder.Entity<Player_Match>().HasData(new List<Player_Match>
        {
            new Player_Match { MatchId = 1, PlayerId = 1, MVPs = 1, Rating = 10.99 },
            new Player_Match { MatchId = 2, PlayerId = 2, MVPs = 2, Rating = 41.50 },
            new Player_Match { MatchId = 3, PlayerId = 3, MVPs = 3, Rating = 3.75 }
        });

        modelBuilder.Entity<Match>().HasData(new List<Match>
        {
            new Match { MatchId = 1, TournamentId = 1, MapId =1, MatchDate= DateTime.Parse("2026-06-01"), Team1Score = 5 , Team2Score = 5 , BestRating = 3.0},
            new Match { MatchId = 2, TournamentId = 2, MapId =2, MatchDate= DateTime.Parse("2023-06-02"), Team1Score = 4 , Team2Score = 4 , BestRating = 2.4},
            new Match { MatchId = 3, TournamentId = 3, MapId =3,MatchDate= DateTime.Parse("2024-06-03"), Team1Score = 1 , Team2Score = 2, BestRating = 1.0}
        });
    }

}