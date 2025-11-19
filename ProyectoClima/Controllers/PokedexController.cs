using Aplication.UseCases.Pokedex.GetPokemonByNameOrId;
using Aplication.UseCases.Pokedex.GetPokemonsPaginated;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoClima.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PokedexController : ControllerBase
    {
        private readonly IGetPokemonByNameHandler _getPokemonByNameHandler;
        private readonly IGetPokemonsPaginatedHandler _getPokemonsPaginatedHandler;
        private readonly ILogger<PokedexController> _logger;

        public PokedexController(
            IGetPokemonByNameHandler getPokemonByNameHandler,
            IGetPokemonsPaginatedHandler getPokemonsPaginatedHandler,
            ILogger<PokedexController> logger)
        {
            _getPokemonByNameHandler = getPokemonByNameHandler;
            _getPokemonsPaginatedHandler = getPokemonsPaginatedHandler;
            _logger = logger;
        }

        [HttpGet("list")]
        public async Task<PokemonsPaginatedResource> Get(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _getPokemonsPaginatedHandler.GetPokemonsPaginated(
                new Pagination(
                    pageNumber,
                    pageSize));

            return result;
        }

        [HttpGet("{pokemon}")]
        public async Task<PokemonByNameResource> Get(string pokemon)
        {
            return await _getPokemonByNameHandler.GetPokemonByNameOrId(pokemon);
        }
    }
}
