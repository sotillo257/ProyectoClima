using Domain.Entity;
using System.Threading.Tasks;

namespace Domain.Repository;

public interface IPokedexRepository
{
    Task<Pokedex> GetPokemonByNameOrId(string pokemon);
}