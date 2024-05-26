namespace Superheroes.Persistence.Repositories
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly Lazy<IRepository<Superhero>> _superheroRepository;
        private readonly Lazy<IRepository<Ability>> _abilityRepository;

        public FakeUnitOfWork()
        {
            _superheroRepository = new Lazy<IRepository<Superhero>>(() => new FakeSuperheroRepository());
            _abilityRepository = new Lazy<IRepository<Ability>>(() => new FakeAbilityRepository());
        }

        public IRepository<Superhero> SuperheroRepository => _superheroRepository.Value;
        public IRepository<Ability> AbilityRepository => _abilityRepository.Value;

        public Task CreateDataBaseAsync() => Task.CompletedTask;
        public Task DeleteDataBaseAsync() => Task.CompletedTask;
        public Task SaveAllAsync() => Task.CompletedTask;
    }
}
