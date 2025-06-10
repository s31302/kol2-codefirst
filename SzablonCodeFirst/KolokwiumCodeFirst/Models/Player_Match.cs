using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumCodeFirst.Models;

[Table("Player_Match")]
[PrimaryKey(nameof(MatchId), nameof(PlayerId))]
public class Player_Match
{
    [ForeignKey(nameof(Match))]
    public int MatchId { get; set; }
    
    [ForeignKey(nameof(Player))]
    public int PlayerId { get; set; }
    
    public int MVPs { get; set; }
    
    [DataType("decimal")]
    [Precision(10, 2)]
    public double Rating { get; set; } 
    
    public Player Player { get; set; }
    
    public Match Match { get; set; }
    
}