using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Service.Models;
public class PokemonInfoModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Habitat { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public IEnumerable<string> Types { get; set; }
    public string Sprite { get; set; }
    public string ShinySprite { get; set; }
    public string Cry { get; set; }
    public string FormattedName => Name.First().ToString().ToUpper() + Name.Substring(1);
}
