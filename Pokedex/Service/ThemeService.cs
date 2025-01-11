using Pokedex.Resources.Styles;

namespace Pokedex.Service;
public class ThemeService
{
    public void SetColorSet(string themeName)
    {
        ResourceDictionary colorSet = themeName switch
        {
            "Charmander" => new ColorsSetRed(),
            "Squirtle" => new ColorsSetBlue(),
            "Bulbasaur" => new ColorsSetGreen(),
            "Pikachu" => new ColorsSetYellow(),
            _ => null
        };

        if (colorSet != null)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(new ColorsGeneric());
            Application.Current.Resources.MergedDictionaries.Add(colorSet);
            Application.Current.Resources.MergedDictionaries.Add(new Styles());
        }
    }
}
