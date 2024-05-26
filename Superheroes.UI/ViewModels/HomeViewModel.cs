using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace Superheroes.UI.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        public HomeViewModel()
        {
            NavigateToSuperheroesCommand = new AsyncRelayCommand(NavigateToSuperheroes);
        }

        public IAsyncRelayCommand NavigateToSuperheroesCommand { get; }

        private async Task NavigateToSuperheroes()
        {
            // Assuming MainPage is the page with NavigationPage
            await Shell.Current.GoToAsync(nameof(MainPage));
        }
    }
}
