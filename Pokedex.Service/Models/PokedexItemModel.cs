using CommunityToolkit.Mvvm.ComponentModel;

namespace Pokedex.Service.Models;

public partial class PokedexItemModel : ObservableObject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FormattedName => Name.First().ToString().ToUpper() + Name.Substring(1);
    public string Url { get; set; }
    [ObservableProperty] private bool selected;
}
