using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Services.Core.Domain.Entities;
using Movies.Services.Infrastructure.Persistence.CQRS.Commands.Create;
using Movies.Services.Infrastructure.Persistence.CQRS.Commands.Delete;
using Movies.Services.Infrastructure.Persistence.CQRS.Commands.Update;
using Movies.Services.Infrastructure.Persistence.CQRS.Queries.GetAll;
using Movies.Services.Infrastructure.Persistence.CQRS.Queries.GetById;
using Movies.Services.Presentation.API.Filters;
using Movies.Shared.ControllerBases;
using Movies.Shared.Dtos;

namespace Movies.Services.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class FilmsController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public FilmsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllFilmQuery());

            return CreateActionResultInstance(response);
        }

        [ServiceFilter(typeof(NotFoundFilter<Films>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetByIdFilmQuery { Id = id});

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFilmCommand createFilmCommand)
        {
            var response = await _mediator.Send(createFilmCommand);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFilmCommand updateFilmCommand)
        {
            var response = await _mediator.Send(updateFilmCommand);

            return CreateActionResultInstance(response);
        }

        [ServiceFilter(typeof(NotFoundFilter<Films>))]
        [HttpDelete("{id}")]  //id belirtiyoruz ki api/questions/5  5 id li veriyi siler.
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteFilmCommand { Id = id});

            return CreateActionResultInstance(response);
        }
    }
}
