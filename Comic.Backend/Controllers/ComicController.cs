using Comic.Backend.Model;
using Comic.Backend.Model.Filter;
using Comic.Backend.Service.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comic.Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ComicController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IHeroService _heroService;
        public ComicController(IConfiguration configuration,
            IHeroService heroService
            )
        {
            _configuration = configuration;
            _heroService = heroService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hero>>> GetAll()
        {

            var filter = new HeroFilter();

            var characters = await _heroService.GetAllAsync(filter);
            return Ok(characters);
        }

        [HttpGet]
        public async Task<ActionResult<Hero>> GetById([FromQuery] int id)
        {
            var filter = new HeroFilter { Id = id };
            var character = await _heroService.GetByIdAsync(filter);
            if (character != null)
            {
                return Ok(character);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<GenericResult>> SaveCharacter([FromBody] Hero hero)
        {
            try
            {
                var character = await _heroService.SaveCharacterAsync(hero);
                if (character != null)
                {
                    return Ok(character);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return BadRequest();
        }
    }
}

