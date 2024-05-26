using System.Linq.Expressions;

namespace Superheroes.Persistence.Repositories
{
    public class FakeSuperheroRepository : IRepository<Superhero>
    {
        private readonly List<Superhero> _superheroes;

        public FakeSuperheroRepository() => _superheroes =
            [
                new() { Id = 1, Name = "Superman", PowerLevel = 100, ImagePath = "superman.jpg", Abilities = [] },
                new() { Id = 2, Name = "Batman", PowerLevel = 85, ImagePath = "batman.jpg", Abilities = [] }
            ];

        public Task<Superhero?> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Superhero, object>>[] includesProperties)
        {
            return Task.FromResult<Superhero?>(_superheroes.FirstOrDefault(s => s.Id == id));
        }

        public Task<IReadOnlyList<Superhero>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult((IReadOnlyList<Superhero>)_superheroes);
        }

        public Task<IReadOnlyList<Superhero>> ListAsync(Expression<Func<Superhero, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Superhero, object>>[] includesProperties)
        {
            return Task.FromResult((IReadOnlyList<Superhero>)_superheroes.Where(filter.Compile()).ToList());
        }

        public Task AddAsync(Superhero entity, CancellationToken cancellationToken = default)
        {
            _superheroes.Add(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Superhero entity, CancellationToken cancellationToken = default)
        {
            var index = _superheroes.FindIndex(s => s.Id == entity.Id);
            if (index >= 0)
            {
                _superheroes[index] = entity;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Superhero entity, CancellationToken cancellationToken = default)
        {
            _superheroes.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Superhero?> FirstOrDefaultAsync(Expression<Func<Superhero, bool>> filter, CancellationToken cancellationToken = default)
        {
            return Task.FromResult<Superhero?>(_superheroes.FirstOrDefault(filter.Compile()));
        }
    }
}
