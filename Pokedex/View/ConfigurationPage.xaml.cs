using Pokedex.ViewModel;

namespace Pokedex.View;

public partial class ConfigurationPage
{
    ConfigurationViewModel vm => BindingContext as ConfigurationViewModel;
    public ConfigurationPage()
	{
		InitializeComponent();

        BindingContext = DependencyService.Resolve<ConfigurationViewModel>(DependencyFetchTarget.NewInstance);
        vm.SetNavigation(Navigation);
    }

}