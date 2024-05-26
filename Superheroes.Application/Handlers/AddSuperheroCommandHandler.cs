using Superheroes.Application.Commands;

namespace Superheroes.Application.Handlers
{
    public class AddSuperheroCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddSuperheroCommand, Superhero>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Superhero> Handle(AddSuperheroCommand request, CancellationToken cancellationToken)
        {
            var newSuperhero = new Superhero
            {
                Name = request.Name,
                PowerLevel = request.PowerLevel,
                ImagePath = request.ImagePath,
                Abilities = []
            };

            await _unitOfWork.SuperheroRepository.AddAsync(newSuperhero, cancellationToken);
            await _unitOfWork.SaveAllAsync();

            return newSuperhero;
        }
    }
}
