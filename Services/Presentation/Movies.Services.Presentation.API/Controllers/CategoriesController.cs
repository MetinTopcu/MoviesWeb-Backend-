using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Services.Infrastructure.Persistence.CQRS.Commands.Create;
using Movies.Services.Infrastructure.Persistence.CQRS.Commands.Delete;
using Movies.Services.Infrastructure.Persistence.CQRS.Commands.Update;
using Movies.Services.Infrastructure.Persistence.CQRS.Queries.GetAll;
using Movies.Services.Infrastructure.Persistence.CQRS.Queries.GetById;
using Movies.Shared.ControllerBases;

namespace Movies.Services.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllCategoryQuery());

            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetByIdCategoryQuery { Id = id});

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommand updateCategoryCommand)
        {
            var response = await _mediator.Send(updateCategoryCommand);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]  //id belirtiyoruz ki api/questions/5  5 id li veriyi siler.
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteCategoryCommand { Id = id});

            return CreateActionResultInstance(response);
        }
    }
}
