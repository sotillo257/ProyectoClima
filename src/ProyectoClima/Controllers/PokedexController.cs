using Aplication.UseCases.Pokedex.GetPokemonByNameOrId;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ProyectoClima.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PokedexController : ControllerBase
    {
        private readonly IGetPokemonByNameHandler _getPokemonByNameHandler;
        private readonly ILogger<PokedexController> _logger;

        public PokedexController(IGetPokemonByNameHandler getPokemonByNameHandler, ILogger<PokedexController> logger)
        {
            _getPokemonByNameHandler = getPokemonByNameHandler;
            _logger = logger;
        }

        [HttpGet("{pokemon}")]
        public async Task<PokemonByNameResource> Get(string pokemon)
        {
            return await _getPokemonByNameHandler.GetPokemonByNameOrId(pokemon);
        }
    }
}
