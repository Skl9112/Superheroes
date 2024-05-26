using System.Linq.Expressions;

namespace Superheroes.Persistence.Repositories
{
    public class FakeAbilityRepository : IRepository<Ability>
    {
        private readonly List<Ability> _abilities;

        public FakeAbilityRepository() => _abilities =
            [
                new() { Id = 1, Name = "Flying", PowerLevel = 100, SuperheroId = 1 },
                new() { Id = 2, Name = "Strength", PowerLevel = 85, SuperheroId = 2 }
            ];

        public Task<Ability?> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Ability, object>>[] includesProperties)
        {
            return Task.FromResult<Ability?>(_abilities.FirstOrDefault(a => a.Id == id));
        }

        public Task<IReadOnlyList<Ability>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult((IReadOnlyList<Ability>)_abilities);
        }

        public Task<IReadOnlyList<Ability>> ListAsync(Expression<Func<Ability, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Ability, object>>[] includesProperties)
        {
            return Task.FromResult((IReadOnlyList<Ability>)_abilities.Where(filter.Compile()).ToList());
        }

        public Task AddAsync(Ability entity, CancellationToken cancellationToken = default)
        {
            _abilities.Add(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Ability entity, CancellationToken cancellationToken = default)
        {
            var index = _abilities.FindIndex(a => a.Id == entity.Id);
            if (index >= 0)
            {
                _abilities[index] = entity;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Ability entity, CancellationToken cancellationToken = default)
        {
            _abilities.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Ability?> FirstOrDefaultAsync(Expression<Func<Ability, bool>> filter, CancellationToken cancellationToken = default)
        {
            return Task.FromResult<Ability?>(_abilities.FirstOrDefault(filter.Compile()));
        }
    }
}
