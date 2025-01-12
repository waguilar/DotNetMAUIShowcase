# Pokémon Info App

This .NET MAUI application connects to the [PokéAPI](https://pokeapi.co/) to fetch and display information about Pokémon. The app is designed with several key features and follows best practices in modern app development.

## Features

- **PokéAPI Integration**: The app connects to the PokéAPI to retrieve detailed information about Pokémon.
- **Local Cache**: API responses are stored locally to improve performance and reduce the number of API calls.
- **MVVM Pattern**: The app is built using the Model-View-ViewModel (MVVM) pattern to separate the UI from the business logic.
- **Service Layer**: The app separates the UI from the services that connect to the endpoints and return the models.
- **FFImage Loading**: Pokémon images are displayed using the FFImageLoading library for efficient image loading and caching.
- **Custom Shell Implementation**: The app uses a custom shell implementation to animate the flyout menu and page transitions.
- **Dynamic Themes**: The app supports dynamic theme changes, allowing users to switch between light and dark themes on the fly.
- **WebView Integration**: The app includes a WebView to display your Gravatar.

## TODO

- **Local Database**: Implement a local database to store the models for offline access.

## Getting Started

### Prerequisites

- Visual Studio 2022
- .NET 9 SDK

### Installation

1. Clone the repository:

git clone https://github.com/yourusername/pokemon-info-app.git

2. Open the solution in Visual Studio 2022.

### Running the App

1. Build the solution.
2. Deploy the app to your preferred device or emulator.

## Project Structure

- **Models**: Contains the data models used in the app.
- **ViewModels**: Contains the view models that handle the business logic and data binding.
- **Views**: Contains the XAML pages that define the UI.
- **Services**: Contains the services that handle API calls and data caching.
- **Resources**: Contains styles and themes for the app.

## Libraries Used

- **FFImageLoading**: For efficient image loading and caching.
- **.NET MAUI**: For building cross-platform applications.
- **SimpleToolkit**: For customizing navigation transitions.
- **CommunityToolkit.Maui**: Provides a collection of reusable elements for .NET MAUI applications.
- **CommunityToolkit.Mvvm**: Provides MVVM utilities to simplify the implementation of the MVVM pattern.
- **RestSharp**: For making HTTP requests to the PokéAPI.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

You're welcome to use the code however you want.
Pokémon and Pokémon character names are trademarks of Nintendo.
