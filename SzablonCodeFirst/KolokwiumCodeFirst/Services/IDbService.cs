using KolokwiumCodeFirst.Data;
using KolokwiumCodeFirst.DTOs;

namespace KolokwiumCodeFirst.Services;

public interface IDbService
{
    
    Task<PlayerMatchDTO> GetPlayerMatch(int playerId);
    Task AddNewPlayer(NewPlayerDTO newPlayerDto);
}