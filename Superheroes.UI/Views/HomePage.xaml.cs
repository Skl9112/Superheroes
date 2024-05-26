using Microsoft.Maui.Controls;
using Superheroes.UI.ViewModels;

namespace Superheroes.UI.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }
}
