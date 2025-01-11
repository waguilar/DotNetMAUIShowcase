using Pokedex.Service.Models;
using Pokedex.ViewModel;

namespace Pokedex.View;

public partial class PokemonDetailPage
{
    PokemonDetailViewModel vm => BindingContext as PokemonDetailViewModel;
    public PokemonDetailPage(PokemonModel pokemon)
    {
        InitializeComponent();

        BindingContext = DependencyService.Resolve<PokemonDetailViewModel>(DependencyFetchTarget.NewInstance);
        vm.Pokemon = pokemon;
        vm.SetNavigation(Navigation);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm?.Initialize();
    }
}