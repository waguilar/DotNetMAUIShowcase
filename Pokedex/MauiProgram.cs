using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Fonts;
using Microsoft.Extensions.Logging;
using Serilog;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;

namespace Pokedex
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseFFImageLoading()
                .UseMauiCommunityToolkit()
                .UseSimpleToolkit()
                .UseSimpleShell()
                .DisplayContentBehindBars()
#if ANDROID
                .SetDefaultStatusBarAppearance(Colors.Transparent, true)
                .SetDefaultNavigationBarAppearance(Colors.Transparent, false)
#endif
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("FluentSystemIcons-Regular.ttf", FluentUI.FontFamily);
                });

            builder.Logging.AddSerilog(dispose: true);
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
