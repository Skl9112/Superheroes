using Superheroes.Persistence.Data;

namespace Superheroes.Persistence.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Superhero>> _superheroRepository;
        private readonly Lazy<IRepository<Ability>> _abilityRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _superheroRepository = new Lazy<IRepository<Superhero>>(() => new EfRepository<Superhero>(_context));
            _abilityRepository = new Lazy<IRepository<Ability>>(() => new EfRepository<Ability>(_context));
        }

        public IRepository<Superhero> SuperheroRepository => _superheroRepository.Value;
        public IRepository<Ability> AbilityRepository => _abilityRepository.Value;

        public async Task CreateDataBaseAsync() => await _context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync() => await _context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync() => await _context.SaveChangesAsync();
    }
}
