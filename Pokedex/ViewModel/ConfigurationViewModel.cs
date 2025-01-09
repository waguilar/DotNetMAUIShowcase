using CommunityToolkit.Mvvm.Input;
using Pokedex.Resources.Styles;
using Serilog;

namespace Pokedex.ViewModel;

public partial class ConfigurationViewModel : BaseViewModel
{
    private readonly IConnectivity _connectivity;

    public ConfigurationViewModel(IConnectivity connectivity) : base(connectivity)
    {
        
    }

    [RelayCommand]
    public void OnChangeTheme(string themeName)
    {
        try
        {
            switch (themeName)
            {
                case "Charmander":
                    SetColorSet(new ColorsSetRed());
                    break;
                case "Squirtle":
                    SetColorSet(new ColorsSetBlue());
                    break;
                case "Bulbasaur":
                    SetColorSet(new ColorsSetGreen());
                    break;
                case "Pikachu":
                    SetColorSet(new ColorsSetYellow());
                    break;
            }
        }
        catch
        {
            
        }
    }

    private void SetColorSet(ResourceDictionary colorSet)
    {
        Application.Current.Resources.MergedDictionaries.Clear();
        Application.Current.Resources.MergedDictionaries.Add(colorSet);
        Application.Current.Resources.MergedDictionaries.Add(new Styles());
    }
}
