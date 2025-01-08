using Pokedex.Service.DTOs;
using Pokedex.Service.Models;

namespace Pokedex.Service.Extensions;
public static class PokemonListDtoExtensions
{
    public static IEnumerable<PokedexItemModel> ToPokedexItemModelList(this PokemonListDto dto)
    {
        return dto.Results.Select(p => new PokedexItemModel
        {
            Id = p.Url.GetPokemonIdFromUrl(),
            Name = p.Name,
            Url = p.Url
        });
    }

}
