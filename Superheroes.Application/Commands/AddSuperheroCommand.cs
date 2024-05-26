namespace Superheroes.Application.Commands
{
    public sealed record AddSuperheroCommand(string Name, int PowerLevel, string ImagePath) : IRequest<Superhero> { }
}
