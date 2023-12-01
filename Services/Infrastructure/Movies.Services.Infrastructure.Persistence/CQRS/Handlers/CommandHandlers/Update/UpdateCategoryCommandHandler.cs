using MediatR;
using Movies.Services.Infrastructure.Persistence.CQRS.Commands.Update;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Handlers.CommandHandlers.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ResponseDto<NoContentDto>>
    {
        private readonly AppDbContext _context;

        public UpdateCategoryCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var updateCategory = _context.Categories.FirstOrDefault(x => x.Id == request.Id);
            _context.Categories.Update(new()
            {
                Name = request.Name
                //Id = request.Id,
            });

            _context.SaveChangesAsync();

            return ResponseDto<NoContentDto>.Success(204);
        }
    }
}
