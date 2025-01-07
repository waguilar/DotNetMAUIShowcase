namespace Pokedex.ViewModel;
public abstract class BaseViewModel
{
    protected INavigation Navigation { get; private set; }
    protected IConnectivity Connectivity { get; private set; }

    public Command NavBarLeftIconTappedCommand { get; set; }
    public Command BackCommand { get; set; }


    public BaseViewModel(IConnectivity connectivity)
    {
        Connectivity = connectivity;
        NavBarLeftIconTappedCommand = new Command(OnNavBarLetIconTapped);
        BackCommand = new Command(OnBack);
    }

    protected virtual void OnNavBarLetIconTapped(object obj)
    {
        var mainPage = Application.Current?.Windows.FirstOrDefault()?.Page;
        if (mainPage is FlyoutPage page)
        {
            page.IsPresented = !page.IsPresented;
        }
    }

    protected virtual async void OnBack(object obj)
    {
        await Navigation.PopAsync();
    }

    public void SetNavigation(INavigation navigation)
    {
        Navigation = navigation;
    }

    public virtual async Task<bool> Initialize()
    {
        if (NoInternetAccess)
        {
            //Todo: Show some error message
            return false;
        }
        return true;
    }

    protected bool NoInternetAccess => Connectivity.NetworkAccess != NetworkAccess.Internet;
}
