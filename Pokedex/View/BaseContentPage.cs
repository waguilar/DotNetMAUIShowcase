using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Pokedex.View;

public partial class BaseContentPage : ContentPage
{
    static Thickness? safeArea = null;

    public BaseContentPage()
    {
        HideSoftInputOnTapped = true;
        // If it was already calculated, use the previous information
        if (safeArea != null)
        {
            Padding = safeArea.GetValueOrDefault();
        }

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Needs to be first calculated on the OnAppearing for the SafeAreaInsets to work
        if (safeArea == null)
        {
            safeArea = On<Microsoft.Maui.Controls.PlatformConfiguration.iOS>().SafeAreaInsets();
            Padding = safeArea.GetValueOrDefault();
        }
    }
}
