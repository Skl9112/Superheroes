using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Superheroes.Application.Queries;
using Superheroes.Domain.Entities;
using MediatR;

namespace Superheroes.UI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public MainViewModel(IMediator mediator)
        {
            _mediator = mediator;
            Superheroes = []; 
            LoadSuperheroesCommand = new AsyncRelayCommand(LoadSuperheroes);
        }

        [ObservableProperty]
        private ObservableCollection<Superhero> superheroes;

        public IAsyncRelayCommand LoadSuperheroesCommand { get; }

        private async Task LoadSuperheroes()
        {
            var query = new GetAllSuperheroesQuery();
            var result = await _mediator.Send(query);
            Superheroes = new ObservableCollection<Superhero>(result);
        }
    }
}
