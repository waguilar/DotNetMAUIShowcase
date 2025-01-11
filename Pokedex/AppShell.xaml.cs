using Microsoft.Maui.Controls.Shapes;
using Pokedex.View;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
using SimpleToolkit.SimpleShell.Extensions;
using SimpleToolkit.SimpleShell.Transitions;

namespace Pokedex
{
    public partial class AppShell : SimpleShell
    {
        private const string OpenMenuAnimationKey = "OpenMenuAnimation";
        private const string CloseMenuAnimationKey = "CloseMenuAnimation";
        private const double OpenScale = 0.8;
        private const double PageCornerRadius = 20;

        private double openTranslationX => pageContainer.Width / 1.9d;
        private bool isMenuClosed = true;


        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(PageEnum.PokemonListPage.ToString(), typeof(PokemonListPage));

            this.SetTransition(
                callback: static args =>
                {
                    switch (args.TransitionType)
                    {
                        case SimpleShellTransitionType.Switching:
                            if (args.OriginShellSectionContainer == args.DestinationShellSectionContainer)
                            {
                                // Navigatating within the same ShellSection
                                args.OriginPage.Opacity = 1 - args.Progress;
                                args.DestinationPage.Opacity = args.Progress;
                            }
                            else
                            {
                                // Navigatating between different ShellSections
                                (args.OriginShellSectionContainer ?? args.OriginPage).Opacity = 1 - args.Progress;
                                (args.DestinationShellSectionContainer ?? args.DestinationPage).Opacity = args.Progress;
                            }
                            break;
                        case SimpleShellTransitionType.Pushing:
                            // Hide the page until it is fully measured
                            args.DestinationPage.Opacity = args.DestinationPage.Width < 0 ? 0.01 : 1;
                            // Slide the page in from right
                            args.DestinationPage.TranslationX = (1 - args.Progress) * args.DestinationPage.Width;
                            break;
                        case SimpleShellTransitionType.Popping:
                            // Slide the page out to right
                            args.OriginPage.TranslationX = args.Progress * args.OriginPage.Width;
                            break;
                    }
                },
                finished: static args =>
                {
                    args.OriginPage.Opacity = 1;
                    args.OriginPage.TranslationX = 0;
                    args.DestinationPage.Opacity = 1;
                    args.DestinationPage.TranslationX = 0;
                    if (args.OriginShellSectionContainer is not null)
                        args.OriginShellSectionContainer.Opacity = 1;
                    if (args.DestinationShellSectionContainer is not null)
                        args.DestinationShellSectionContainer.Opacity = 1;
                },
                destinationPageInFront: static args => args.TransitionType switch
                {
                    SimpleShellTransitionType.Popping => false,
                    _ => true
                },
                duration: static args => args.TransitionType switch
                {
                    SimpleShellTransitionType.Switching => 300u,
                    _ => 200u
                },
                easing: static args => args.TransitionType switch
                {
                    SimpleShellTransitionType.Pushing => Easing.SinIn,
                    SimpleShellTransitionType.Popping => Easing.SinOut,
                    _ => Easing.Linear
                }
            );

            pageContainer.SizeChanged += PageContainerSizeChanged;

            Loaded += AppShellLoaded;
        }

        private void AppShellLoaded(object sender, EventArgs e)
        {
            Window.SubscribeToSafeAreaChanges(safeArea =>
            {
                appBar.Margin = safeArea;
                menuGrid.Margin = safeArea;
            });
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
            pageOverlay.InputTransparent = true;
        }

        private void OpenMenu()
        {
            isMenuClosed = false;

            pageContainer.AbortAnimation(OpenMenuAnimationKey);
            pageContainer.AbortAnimation(CloseMenuAnimationKey);

            // TODO: On Android, change of the InputTransparent property value does not work
            pageOverlay.InputTransparent = false;
            pageContainer.Clip = new RoundRectangleGeometry(new CornerRadius(PageCornerRadius), new Rect(0, 0, pageContainer.Width, pageContainer.Height));

            Animation animation = new Animation(d =>
            {
                pageContainer.Scale = 1 - ((1 - OpenScale) * d);
                pageContainer.TranslationX = openTranslationX * d;
            });

            animation.Commit(pageContainer, OpenMenuAnimationKey, finished: (d, b) =>
            {
                pageContainer.Scale = OpenScale;
                pageContainer.TranslationX = openTranslationX;
            });
        }

        private void CloseMenu()
        {
            isMenuClosed = true;

            pageContainer.AbortAnimation(OpenMenuAnimationKey);
            pageContainer.AbortAnimation(CloseMenuAnimationKey);

            Animation animation = new Animation(d =>
            {
                pageContainer.Scale = OpenScale + ((1 - OpenScale) * d);
                pageContainer.TranslationX = openTranslationX - (openTranslationX * d);
            });

            animation.Commit(pageContainer, CloseMenuAnimationKey, finished: (d, b) =>
            {
                pageContainer.Scale = 1;
                pageContainer.TranslationX = 0;
                pageOverlay.InputTransparent = true;

                pageContainer.Clip = null;
            });
        }

        private void AppBarMenuClicked(object sender, EventArgs e)
        {
            if (isMenuClosed)
                OpenMenu();
        }

        private void CloseMenuButtonClicked(object sender, EventArgs e)
        {
            if (!isMenuClosed)
                CloseMenu();
        }

        private void AppBarBackClicked(object sender, EventArgs e)
        {
            GoToAsync("..");
        }

        private void MenuItemButtonClicked(object sender, EventArgs e)
        {
            var view = sender as Microsoft.Maui.Controls.View;
            var shellItem = view.BindingContext as BaseShellItem;

            GoToAsync($"///{shellItem.Route}");
            CloseMenu();
        }

        private void PageContainerSizeChanged(object sender, EventArgs e)
        {
            menuGrid.HeightRequest = pageContainer.Height * OpenScale;

            if (!isMenuClosed)
                CloseMenu();
        }

    }
}
