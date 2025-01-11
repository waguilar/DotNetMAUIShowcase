using Pokedex.ViewModel;

namespace Pokedex.View;

public partial class PokemonListPage
{
    PokemonListViewModel vm => BindingContext as PokemonListViewModel;
    public PokemonListPage()
    {
        InitializeComponent();

        BindingContext = DependencyService.Resolve<PokemonListViewModel>();
        vm.SetNavigation(Navigation);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm?.Initialize();
    }
}
