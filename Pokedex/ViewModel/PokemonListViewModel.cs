using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pokedex.Service;
using Pokedex.Service.Models;
using Pokedex.Service.Services;
using Pokedex.View;

namespace Pokedex.ViewModel;

public partial class PokemonListViewModel : BaseViewModel
{
    private readonly PokemonService _pokemonService;
    private readonly UserDialogService _userDialogService;

    [ObservableProperty] private PokemonModel pokemon;
    [ObservableProperty] private ObservableCollection<PokedexItemModel> pokemonList;
    [ObservableProperty] private PokedexItemModel selectedItem;


    public PokemonListViewModel() : this(DependencyService.Resolve<IConnectivity>(),
        DependencyService.Resolve<PokemonService>(),
        DependencyService.Resolve<UserDialogService>())
    {
    }

    public PokemonListViewModel(IConnectivity connectivity,
        PokemonService pokemonService,
        UserDialogService userDialogService) : base(connectivity)
    {
        _pokemonService = pokemonService;
        _userDialogService = userDialogService;
    }


    partial void OnSelectedItemChanging(PokedexItemModel? oldValue, PokedexItemModel newValue)
    {
        if (oldValue is not null)
        {
            oldValue.Selected = false;
        }
        newValue.Selected = true;
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
        var result = await _pokemonService.GetPokemonList(offset, 150, CancellationToken.None);

        if (PokemonList == null) PokemonList = new ObservableCollection<PokedexItemModel>();

        PokemonList.Clear();
        foreach (var item in result) PokemonList.Add(item);
    }

    private async Task LoadPokemonAsync(int id)
    {
        Pokemon = await _pokemonService.GetPokemonById(id, CancellationToken.None);
    }

    [RelayCommand]
    private async Task GoToDetailAsync()
    {
        if (SelectedItem is null)
        {
            await _userDialogService.ShowToast("Select a Pokémon first!", CancellationToken.None);
            return;
        }
        await Navigation.PushAsync(new PokemonDetailPage(Pokemon));
    }
}