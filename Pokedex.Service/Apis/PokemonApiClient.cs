using Pokedex.Service.Interfaces;
using RestSharp;
using System.Collections.Concurrent;
using Pokedex.Service.DTOs;

namespace Pokedex.Service.Apis;
public class PokemonApiClient : BaseApiClient
{
    private readonly ConcurrentDictionary<string, PokemonListDto> _pokemonListDtoCache = new();
    private readonly ConcurrentDictionary<string, PokemonInfoDto> _pokemonDtocache = new();
    private readonly ConcurrentDictionary<string, PokemonSpeciesDto> _pokemonSpeciesDtocache = new();

    public PokemonApiClient(ILogService logService) : base(logService)
    {
    }

    public async Task<PokemonListDto> GetPokemonList(int offset, int limit, CancellationToken cancellationToken)
    {
        var restRequest = new RestRequest("pokemon");
        restRequest.AddQueryParameter("offset", offset);
        restRequest.AddQueryParameter("limit", limit);

        var cacheKey = RestClient.BuildUri(restRequest).ToString();
        if (_pokemonListDtoCache.TryGetValue(cacheKey, out var cachedResponse))
        {
            return cachedResponse;
        }
        var response = await RestClient.GetAsync<PokemonListDto>(restRequest);

        if (response != null)
        {
            _pokemonListDtoCache[cacheKey] = response;
        }

        return response;
    }

    public async Task<PokemonInfoDto> GetPokemonById(int id, CancellationToken cancellationToken)
    {
        var restRequest = new RestRequest("pokemon/{Id}");
        restRequest.AddUrlSegment("Id", id);

        var cacheKey = RestClient.BuildUri(restRequest).ToString();
        if (_pokemonDtocache.TryGetValue(cacheKey, out var cachedResponse))
        {
            return cachedResponse;
        }

        var response = await RestClient.GetAsync<PokemonInfoDto>(restRequest);

        if (response != null)
        {
            _pokemonDtocache[cacheKey] = response;
        }

        return response;
    }

    public async Task<PokemonSpeciesDto> GetPokemonSpeciesById(int id, CancellationToken cancellationToken)
    {
        var restRequest = new RestRequest("pokemon-species/{Id}");
        restRequest.AddUrlSegment("Id", id);

        var cacheKey = RestClient.BuildUri(restRequest).ToString();
        if (_pokemonSpeciesDtocache.TryGetValue(cacheKey, out var cachedResponse))
        {
            return cachedResponse;
        }

        var response = await RestClient.GetAsync<PokemonSpeciesDto>(restRequest);

        if (response != null)
        {
            _pokemonSpeciesDtocache[cacheKey] = response;
        }

        return response;
    }

}
