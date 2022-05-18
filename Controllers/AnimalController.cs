using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zad3.Models;
using zad3.Services;

namespace zad3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IDbService _dbService;

        public AnimalController(IDbService dbService)
        {
            _dbService = dbService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAnimals(string orderBy)
        {
            //DbService db = new(); NIEDOBRE PODEJŚCIE

            IList<Animal> result = await _dbService.GetAnimalListAsync();

            return Ok(result);
        }
    }
}