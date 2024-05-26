using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace Superheroes.UI
{
    public partial class App : IApplication
    {
        public App(AppShell appShell)
        {
            InitializeComponent();
            MainPage = appShell;
        }

        public static new App Current => (App)IApplication.Current;

        public IServiceProvider Services => MauiProgram.Services;
    }
}
