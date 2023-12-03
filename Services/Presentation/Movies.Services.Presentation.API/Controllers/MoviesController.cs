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

namespace Movies.Services.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MoviesController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllMovieQuery());

            return CreateActionResultInstance(response);
        }

        [ServiceFilter(typeof(NotFoundFilter<Movie>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetByIdMovieQuery { Id = id });

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieCommand createMovieCommand)
        {
            var response = await _mediator.Send(createMovieCommand);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMovieCommand updateMovieCommand)
        {
            var response = await _mediator.Send(updateMovieCommand);

            return CreateActionResultInstance(response);
        }

        [ServiceFilter(typeof(NotFoundFilter<Movie>))]
        [HttpDelete("{id}")]  //id belirtiyoruz ki api/questions/5  5 id li veriyi siler.
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteMovieCommand { Id = id });

            return CreateActionResultInstance(response);
        }
    }
}
