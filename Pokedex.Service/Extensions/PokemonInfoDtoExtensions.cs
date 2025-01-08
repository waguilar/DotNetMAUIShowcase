using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Service.DTOs;
using Pokedex.Service.Models;

namespace Pokedex.Service.Extensions;
public static class PokemonInfoDtoExtensions
{
    public static PokemonInfoModel ToPokemonInfoModel(this PokemonInfoDto dto)
    {
        return new PokemonInfoModel()
        {
            Id = dto.Id,
            Name = dto.Name,
            Sprite = dto.Sprites.FrontDefault,
            ShinySprite = dto.Sprites.FrontShiny,
            Height = dto.Height,
            Weight = dto.Weight,
            Types = dto.Types.Select(t => t.TypeResource.Name),
            Cry = dto.Cries.Latest,
        };
    }
}
