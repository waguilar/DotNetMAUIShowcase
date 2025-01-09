﻿using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microsoft.Extensions.Logging;
using Pokedex.Service.Apis;
using Pokedex.Service.Constants;
using Pokedex.Service.Interfaces;
using Pokedex.Service.Services;
using Pokedex.View;
using Pokedex.ViewModel;
using Serilog;

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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Logging.AddSerilog(dispose: true);

            builder.Services.AddSingleton(Connectivity.Current);

            // Services - Api Client
            var apiClient = new PokemonApiClient(DependencyService.Resolve<ILogService>());
            apiClient.Initialize(ServiceConstants.BaseUrl);
            builder.Services.AddSingleton(apiClient);

            builder.Services.AddSingleton<ILogService, LogService>();
            builder.Services.AddSingleton<PokemonService>();

            // Register ViewModels
            builder.Services.AddTransient<PokemonListViewModel>();
            builder.Services.AddTransient<ConfigurationViewModel>();

            // Register Views
            builder.Services.AddTransient<PokemonListPage>();
            builder.Services.AddTransient<ConfigurationPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
