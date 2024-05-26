namespace Superheroes.Application.Queries
{
    public sealed record GetAllSuperheroesQuery : IRequest<IEnumerable<Superhero>> { }
}
