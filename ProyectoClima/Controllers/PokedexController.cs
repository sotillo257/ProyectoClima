using Aplication.UseCases.Pokedex.GetPokemonByNameOrId;
using Aplication.UseCases.Pokedex.GetPokemonsPaginated;
using Aplication.UseCases.Pokedex.GetLocationsPaginated;
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
        private readonly IGetLocationsPaginatedHandler _getLocationsPaginatedHandler;
        private readonly ILogger<PokedexController> _logger;

        public PokedexController(
            IGetPokemonByNameHandler getPokemonByNameHandler,
            IGetPokemonsPaginatedHandler getPokemonsPaginatedHandler,
            IGetLocationsPaginatedHandler getLocationsPaginatedHandler,
            ILogger<PokedexController> logger)
        {
            _getPokemonByNameHandler = getPokemonByNameHandler;
            _getPokemonsPaginatedHandler = getPokemonsPaginatedHandler;
            _getLocationsPaginatedHandler = getLocationsPaginatedHandler;
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

        [HttpGet("location")]
        public async Task<LocationsPaginatedResource> GetLocations(int pageNumber = 1, int pageSize = 10, string sortBy = "name", string sortOrder = "asc")
        {
            var result = await _getLocationsPaginatedHandler.GetLocationsPaginated(
                new Pagination(
                    pageNumber,
                    pageSize,
                    sortBy,
                    sortOrder));

            return result;
        }
    }
}
