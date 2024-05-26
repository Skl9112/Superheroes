using Microsoft.Maui.Controls;
using Superheroes.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Superheroes.UI.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = App.Current.Services.GetRequiredService<MainViewModel>();
        }
    }
}
