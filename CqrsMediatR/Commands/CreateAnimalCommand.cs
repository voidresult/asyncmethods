using CqrsMediatR.Data;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsMediatR.Commands
{
    public class CreateAnimalCommand : IRequest<Animal>
    {
        public string Name { get; set; }
        public int AnimalKindId { get; set; }
    }
    public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, Animal>
    {
        private readonly IRepository<Animal, int> repositoryAnimal;

        public CreateAnimalCommandHandler(IRepository<Animal, int> repositoryAnimal)
        {
            this.repositoryAnimal = repositoryAnimal;
        }
        public async Task<Animal> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            Animal animal = new Animal
            {
                Name = request.Name,
                AnimalKindId = request.AnimalKindId
            };
            return await repositoryAnimal.Create(animal);
        }
        public class CreateAnimalCommandValidator : AbstractValidator<CreateAnimalCommand>
        {
            public CreateAnimalCommandValidator()
            {
                RuleFor(c => c.Name).NotEmpty();
                RuleFor(c => c.AnimalKindId > 0).NotEmpty();
            }
        }
    }
}

