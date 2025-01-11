using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pokedex.Models;
using Pokedex.Resources.Styles;
using Pokedex.Service;

namespace Pokedex.ViewModel;

public partial class ConfigurationViewModel : BaseViewModel
{
    private readonly IConnectivity _connectivity;
    private readonly ThemeService _themeService;

    [ObservableProperty] private List<LanguageItemModel> languages;
    [ObservableProperty] private LanguageItemModel selectedLanguage;

    public ConfigurationViewModel() : this(DependencyService.Resolve<IConnectivity>(),
        DependencyService.Resolve<ThemeService>())
    {
        
    }

    public ConfigurationViewModel(IConnectivity connectivity,
        ThemeService themeService) : base(connectivity)
    {
        _connectivity = connectivity;
        _themeService = themeService;
        Languages = new List<LanguageItemModel>()
        {
            new LanguageItemModel() { Key = "en", Name = "English" },
            new LanguageItemModel() { Key = "es", Name = "Spanish" },
            new LanguageItemModel() { Key = "fr", Name = "French" },
            new LanguageItemModel() { Key = "de", Name = "German" },
            new LanguageItemModel() { Key = "it", Name = "Italian" },
            new LanguageItemModel() { Key = "ja", Name = "Japanese" },
            new LanguageItemModel() { Key = "ko", Name = "Korean" },
            new LanguageItemModel() { Key = "zh-Hant", Name = "Chinese" }
        };
        SelectedLanguage = Languages.First(x => x.Key == Preferences.Get("languageKey", "en"));
    }

    partial void OnSelectedLanguageChanged(LanguageItemModel value)
    {
        Preferences.Set("languageKey", value.Key);
    }

    [RelayCommand]
    public void OnChangeTheme(string themeName)
    {
        try
        {
            _themeService.SetColorSet(themeName);
            Preferences.Set("themeKey", themeName);
        }
        catch(Exception ex)
        {
            
        }
    }

}
