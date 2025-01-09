using Pokedex.ViewModel;

namespace Pokedex.View;

public partial class ConfigurationPage
{
    ConfigurationViewModel vm => BindingContext as ConfigurationViewModel;
    public ConfigurationPage(ConfigurationViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
        vm.SetNavigation(Navigation);
    }

}