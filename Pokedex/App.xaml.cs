using Pokedex.Service;
using Pokedex.Service.Apis;
using Pokedex.Service.Constants;
using Pokedex.Service.Interfaces;
using Pokedex.Service.Services;
using Pokedex.View;
using Pokedex.ViewModel;

namespace Pokedex
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.RegisterSingleton(Connectivity.Current);

            // Services - Api Client
            var apiClient = new PokemonApiClient(DependencyService.Resolve<ILogService>());
            apiClient.Initialize(ServiceConstants.BaseUrl);
            DependencyService.RegisterSingleton(apiClient);

            DependencyService.Register<ILogService, LogService>();
            DependencyService.Register<PokemonService>();
            var themeService = new ThemeService();
            DependencyService.RegisterSingleton(themeService);

            // Register ViewModels
            DependencyService.Register<PokemonListViewModel>();
            DependencyService.Register<PokemonDetailViewModel>();
            DependencyService.Register<ConfigurationViewModel>();

            // Load and apply the stored theme preference
            var storedTheme = Preferences.Get("themeKey", "Charmander");
            themeService.SetColorSet(storedTheme);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}