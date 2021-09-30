using CqrsMediatR.Commands;
using CqrsMediatR.Data;
using CqrsMediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsMediatR.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IRepository<Animal, int> repositoryAnimal;        
        private readonly IMediator mediator;

        public AnimalsController(IMediator mediator, IRepository<Animal, int> repositoryAnimal)
        {
            this.repositoryAnimal = repositoryAnimal;            
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Animal>> Create([FromBody] CreateAnimalCommand createAnimalCommand, CancellationToken token ) {
            return CreatedAtAction(nameof(Create), await mediator.Send(createAnimalCommand, token));
        }

        [HttpPost]
        public async Task<ActionResult<GetAnimalInfoQueryDto>> GetAnimalInfo([FromBody] GetAnimalInfoQuery getAnimalInfoQuery, CancellationToken token) 
        {            
            return new ObjectResult(await mediator.Send(getAnimalInfoQuery,token));
        }

        [HttpPost]
        public ActionResult<GetAnimalInfoQueryDto> GetAnimalInfoSync([FromBody] GetAnimalInfoQuery getAnimalInfoQuery, CancellationToken token)
        {
            return new ObjectResult(mediator.Send(getAnimalInfoQuery, token).Result);
        }
    }
}
