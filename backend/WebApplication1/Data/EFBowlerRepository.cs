using System.Collections.Generic;
using System.Linq;
using BowlersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BowlersAPI.Data
{
    public class EfBowlerRepository : IBowlerRepository
    {
        private readonly BowlingLeagueContext _context;
        
        public EfBowlerRepository(BowlingLeagueContext context)
        {
            _context = context;
        }

        public IEnumerable<Bowler> Bowlers => _context.Bowlers.ToList();
        
        public IEnumerable<object> GetBowlersWithTeams()
        {
            return _context.Bowlers
                .Include(b => b.Team) // Include the related Team entity
                .Where(b => b.Team.TeamName == "Sharks" || b.Team.TeamName == "Marlins")
                .Select(b => new // Anonymous type
                {
                    BowlerName = $"{b.BowlerFirstName} {b.BowlerMiddleInit} {b.BowlerLastName}",
                    TeamName = b.Team.TeamName,
                    // Include other specific fields from the Bowlers entity as needed
                    Address = b.BowlerAddress,
                    City = b.BowlerCity,
                    State = b.BowlerState,
                    Zip = b.BowlerZip,
                    PhoneNumber = b.BowlerPhoneNumber
                })
                .ToList();
        }


        
        
    }
}
