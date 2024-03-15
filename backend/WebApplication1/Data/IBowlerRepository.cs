namespace BowlersAPI.Models;

public interface IBowlerRepository
{
    IEnumerable<Bowler> Bowlers { get; }
    IEnumerable<object> GetBowlersWithTeams();
}