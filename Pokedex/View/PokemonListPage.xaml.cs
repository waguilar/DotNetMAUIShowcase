using Pokedex.ViewModel;

namespace Pokedex.View;

public partial class PokemonListPage
{
    PokemonListViewModel vm => BindingContext as PokemonListViewModel;
    public PokemonListPage(PokemonListViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
        vm.SetNavigation(Navigation);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm?.Initialize();
    }
}