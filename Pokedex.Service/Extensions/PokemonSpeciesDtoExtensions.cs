using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Service.DTOs;
using Pokedex.Service.Models;

namespace Pokedex.Service.Extensions;
public static class PokemonSpeciesDtoExtensions
{
    public static PokemonSpeciesModel ToPokemonSpeciesModel(this PokemonSpeciesDto dto)
    {
        return new PokemonSpeciesModel()
        {
            Name = dto.Name,
            GeneraDictionary = dto.Genera
                .ToDictionary(k => k.Language.Name, v => v.GenusValue),

            FlavorTextDictionary = dto.FlavorTextEntries
                .Where(w => w.Version.Name == "lets-go-eevee")
                .ToDictionary(k => k.Language.Name, v => v.FlavorTextValue)

        };
    }
}
