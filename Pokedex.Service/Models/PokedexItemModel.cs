namespace Pokedex.Service.Models;

public class PokedexItemModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FormattedName => Name.First().ToString().ToUpper() + Name.Substring(1);
    public string Url { get; set; }
}
