using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Pokedex.View;

public partial class BaseContentPage : ContentPage
{
    public BaseContentPage()
    {
        HideSoftInputOnTapped = true;
        Padding = new Thickness(0, 120, 0, 0);
    }
}
