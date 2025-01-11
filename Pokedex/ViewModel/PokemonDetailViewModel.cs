using CommunityToolkit.Mvvm.ComponentModel;
using Pokedex.Service.Models;

namespace Pokedex.ViewModel;
public partial class PokemonDetailViewModel : BaseViewModel
{
    [ObservableProperty] private PokemonModel pokemon;

    public PokemonDetailViewModel() : this(DependencyService.Resolve<IConnectivity>())
    {
    }

    public PokemonDetailViewModel(IConnectivity connectivity) : base(connectivity)
    {
    }

    public override async Task<bool> Initialize()
    {
        await base.Initialize();

        return true;
    }
}
