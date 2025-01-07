using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Model;

namespace Pokedex.ViewModel;
public class PokemonListViewModel : BaseViewModel
{
    public ObservableCollection<Pokemon> Pokemons { get; set; }

    public PokemonListViewModel(IConnectivity connectivity) : base(connectivity)
    {
        Pokemons = new ObservableCollection<Pokemon>
        {
            new Pokemon { Name = "Bulbasaur", Description = "A strange seed was planted on its back at birth." },
            new Pokemon { Name = "Charmander", Description = "Obviously prefers hot places." },
            // Add more Pokémon
        };
    }
}
