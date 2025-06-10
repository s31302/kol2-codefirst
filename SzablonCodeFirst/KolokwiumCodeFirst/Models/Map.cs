using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumCodeFirst.Models;

[Table("Map")]
public class Map
{
    [Key]
    public int MapId { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }
    
    [MaxLength(100)]
    public string Type { get; set; }
    
    public ICollection<Match> Match { get; set; }

}