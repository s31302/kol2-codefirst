using KolokwiumCodeFirst.Data;
using KolokwiumCodeFirst.DTOs;
using KolokwiumCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumCodeFirst.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    

    public async Task<PlayerMatchDTO> GetPlayerMatch(int playerId)
    {
        var player = await _context.Players.
            Include(p => p.PlayerMatch)
            .ThenInclude(pm => pm.Match)
            .ThenInclude(m => m.Map)
            .Include(p => p.PlayerMatch)
            .ThenInclude(pm => pm.Match)
            .ThenInclude(m => m.Tournament)
            .FirstOrDefaultAsync(p => p.PlayerId == playerId);

        
        if (player == null)
        {
            throw new Exception("Player not found");
        }

        var result = new PlayerMatchDTO
        {
            PlayerId = playerId,
            FirstName = player.FirstName,
            LastName = player.LastName,
            BirthDate = player.BirthDate,
            Matches = player.PlayerMatch.Select(pm => new MatchDTO
            {
                Tournament = pm.Match.Tournament.Name,
                Map = pm.Match.Map.Name,
                Date = pm.Match.MatchDate,
                MVPs = pm.MVPs,
                Rating = pm.Rating,
                Team1Score = pm.Match.Team1Score.ToString(),
                Team2Score = pm.Match.Team2Score.ToString()

            }).ToList(),
        };
        return result;
    }
    
    
    

    
    public async Task AddNewPlayer(NewPlayerDTO newPlayerDto)
    {
        
       
    }

}
