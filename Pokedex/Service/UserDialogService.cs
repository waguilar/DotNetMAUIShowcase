using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Pokedex.Service;
public class UserDialogService
{
    public Task ShowToast(string text, CancellationToken cancellationToken)
    {
        double fontSize = 14;
        var toast = Toast.Make(text, ToastDuration.Long, fontSize);

        return toast.Show(cancellationToken);
    }
}
