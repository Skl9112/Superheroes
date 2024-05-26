using MediatR;
using Microsoft.Extensions.Logging;
using Superheroes.Application;
using Superheroes.Persistence;
using Superheroes.UI.ViewModels;
using Superheroes.UI.Views;

namespace Superheroes.UI
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

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddApplication();
            builder.Services.AddPersistence();

            builder.Services.AddSingleton<MainViewModel>(provider =>
            {
                var mediator = provider.GetRequiredService<IMediator>();
                return new MainViewModel(mediator);
            });
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<HomePage>();

            Services = builder.Services.BuildServiceProvider();

            return builder.Build();
        }

        public static IServiceProvider? Services { get; private set; }
    }
}
