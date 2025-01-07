using Microsoft.Extensions.Logging;
using Pokedex.View;
using Pokedex.ViewModel;

namespace Pokedex
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton(Connectivity.Current);

            // Register ViewModels
            builder.Services.AddTransient<PokemonListViewModel>();

            // Register Views
            builder.Services.AddTransient<PokemonList>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
