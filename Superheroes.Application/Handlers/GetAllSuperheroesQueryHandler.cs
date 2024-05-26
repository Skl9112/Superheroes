using Superheroes.Application.Queries;

namespace Superheroes.Application.Handlers
{
    public class GetAllSuperheroesQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllSuperheroesQuery, IEnumerable<Superhero>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Superhero>> Handle(GetAllSuperheroesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.SuperheroRepository.ListAllAsync(cancellationToken);
        }
    }
}
