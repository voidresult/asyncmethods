using CqrsMediatR.Data;
using MediatR;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsMediatR.Queries
{
    public class GetAnimalInfoQueryDto
    {
        public string AnimalName { get; set; }
        public string AnimalKindName { get; set; }
    }
    public class GetAnimalInfoQuery : IRequest<GetAnimalInfoQueryDto>
    {
        public int IdAnimal { get; set; }
    }
    public class GetAnimalInfoQueryHandler : IRequestHandler<GetAnimalInfoQuery, GetAnimalInfoQueryDto>
    {
        private readonly IRepository<Animal, int> repositoryAnimal;
        private readonly IRepository<AnimalKind, int> repositoryKind;

        public GetAnimalInfoQueryHandler(IRepository<Animal,int> repositoryAnimal, IRepository<AnimalKind,int> repositoryKind)
        {
            this.repositoryAnimal = repositoryAnimal;
            this.repositoryKind = repositoryKind;
        }
        public async Task<GetAnimalInfoQueryDto> Handle(GetAnimalInfoQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<AnimalKind> allKinds = await repositoryKind.GetAll();
            Animal animal = await repositoryAnimal.Get(request.IdAnimal);
            if (animal == null)
                return null;
            GetAnimalInfoQueryDto res = new GetAnimalInfoQueryDto()
            {
                AnimalName = animal.Name,
                AnimalKindName = allKinds?.FirstOrDefault(k => k.Id == animal.AnimalKindId)?.Name
            };
            return res;
        }
    }
}
