using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Service.DTOs;

namespace Pokedex.Service.Models;
public class PokemonSpeciesModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Habitat { get; set; }
    public Dictionary<string,string> GeneraDictionary { get; set; }

    public string Genera => GeneraDictionary
        .First(g => g.Key == Preferences.Get("languageKey", "en"))
        .Value;
    public Dictionary<string,string> FlavorTextDictionary { get; set; }

    public string FlavorText => FlavorTextDictionary
        .First(f => f.Key == Preferences.Get("languageKey", "en"))
        .Value;
    public string FormattedFlavorText => FlavorText.Replace("\n", " ");
}
