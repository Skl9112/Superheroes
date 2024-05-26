using Superheroes.Domain.Entities;

namespace Superheroes.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Superhero> SuperheroRepository { get; }
        IRepository<Ability> AbilityRepository { get; }
        Task SaveAllAsync();
        Task DeleteDataBaseAsync();
        Task CreateDataBaseAsync();
    }
}
