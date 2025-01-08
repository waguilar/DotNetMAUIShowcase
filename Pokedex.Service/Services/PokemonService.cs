using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Service.Apis;
using Pokedex.Service.Extensions;
using Pokedex.Service.Interfaces;
using Pokedex.Service.Models;

namespace Pokedex.Service.Services;
public class PokemonService
{
    readonly PokemonApiClient pokemonApiClient;
    readonly ILogService logService;

    public PokemonService() : this(
        DependencyService.Resolve<PokemonApiClient>(),
        DependencyService.Resolve<ILogService>())
    {
    }

    public PokemonService(
        PokemonApiClient pokemonApiClient, 
        ILogService logService)
    {
        this.pokemonApiClient = pokemonApiClient;
        this.logService = logService;
    }

    public async Task<IEnumerable<PokedexItemModel>> GetPokemonList(int offset, int limit, CancellationToken cancellationToken)
    {
        var pokemonListDto = await pokemonApiClient.GetPokemonList(offset, limit, cancellationToken);
        return pokemonListDto.ToPokedexItemModelList();
    }

    public async Task<PokemonModel> GetPokemonById(int id, CancellationToken cancellationToken)
    {
        var pokemonDto = await pokemonApiClient.GetPokemonById(id, cancellationToken);
        var pokemonModel = new PokemonModel()
        {
            PokemonInfo = pokemonDto.ToPokemonInfoModel()
        };
        return pokemonModel;
    }
}
