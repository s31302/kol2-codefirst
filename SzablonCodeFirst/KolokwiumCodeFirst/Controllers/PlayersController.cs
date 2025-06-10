using KolokwiumCodeFirst.Data;
using KolokwiumCodeFirst.DTOs;
using KolokwiumCodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumCodeFirst.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly IDbService _dbService;

    public PlayersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    
    [HttpGet("{customerId}/matches")]
    public async Task<ActionResult<PlayerMatchDTO>> GetPlayerMatches(int playerId)
    {
        var result = await _dbService.GetPlayerMatch(playerId);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NewPlayerDTO newPlayerDto)
    {
        await _dbService.AddNewPlayer(newPlayerDto);
        return Created();
    }
    
}