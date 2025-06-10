using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumCodeFirst.Models;

[Table(("Tournamen"))]
public class Tournament
{
    [Key]
    public int TournamentId { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public ICollection<Match> Match { get; set; }

}