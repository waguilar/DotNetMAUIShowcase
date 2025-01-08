using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Pokedex.Service.Models;
using Pokedex.Service.Services;

namespace Pokedex.ViewModel;

public partial class PokemonListViewModel : BaseViewModel
{
    private readonly PokemonService pokemonService;

    private int offset = 0;
    [ObservableProperty] private PokemonModel pokemon;
    [ObservableProperty] private ObservableCollection<PokedexItemModel> pokemonList;
    [ObservableProperty] private PokedexItemModel selectedItem;

    public PokemonListViewModel(IConnectivity connectivity,
        PokemonService pokemonService) : base(connectivity)
    {
        this.pokemonService = pokemonService;
    }

    partial void OnSelectedItemChanged(PokedexItemModel value)
    {
        if (SelectedItem != null) LoadPokemonAsync(value.Id);
    }

    public override async Task<bool> Initialize()
    {
        await base.Initialize();

        await LoadPokemonsAsync();

        return true;
    }

    private async Task LoadPokemonsAsync(int offset = 0)
    {
        var result = await pokemonService.GetPokemonList(offset, 20, CancellationToken.None);

        if (PokemonList == null) PokemonList = new ObservableCollection<PokedexItemModel>();

        foreach (var item in result) PokemonList.Add(item);
    }

    private async Task LoadPokemonAsync(int id)
    {
        Pokemon = await pokemonService.GetPokemonById(id, CancellationToken.None);
    }
}