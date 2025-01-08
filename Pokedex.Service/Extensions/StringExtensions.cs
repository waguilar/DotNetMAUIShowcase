using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Service.Extensions;

public static class StringExtensions
{
    public static int GetPokemonIdFromUrl(this string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return 0;
        }

        var segments = url.TrimEnd('/').Split('/');
        if (int.TryParse(segments.Last(), out int id))
        {
            return id;
        }

        throw new FormatException("The URL does not contain a valid Pokemon ID");
    }
}
