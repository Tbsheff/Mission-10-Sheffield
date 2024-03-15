using BowlersAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BowlersController
    {
        private readonly IBowlerRepository _repository;
        
        public BowlersController(IBowlerRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public IEnumerable<Bowler> Get() => _repository.Bowlers;
        
        [HttpGet]
        [Route("teams")]
        public IEnumerable<object> GetBowlersWithTeams()
        {
            var bowlers = _repository.GetBowlersWithTeams();
            return bowlers;
        }
    }


}