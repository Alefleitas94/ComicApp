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
        public async Task<ActionResult<IEnumerable<Hero>>> GetAll([FromQuery]HeroFilter filter = null)
        {
            var products = await _heroService.GetAllAsync(filter);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetById(int id)
        {
            var product = await _heroService.GetByIdAsync(id);
            if (product == null)
            {
                return Ok(product);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

