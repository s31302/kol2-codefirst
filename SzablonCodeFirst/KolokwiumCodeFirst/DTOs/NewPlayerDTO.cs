namespace KolokwiumCodeFirst.DTOs;

public class NewPlayerDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<MatchesDTO> Matches { get; set; }
}

public class MatchesDTO
{
    public int MatchId { get; set; }
    public int MVPs { get; set; }
    public double Rating { get; set; }
}