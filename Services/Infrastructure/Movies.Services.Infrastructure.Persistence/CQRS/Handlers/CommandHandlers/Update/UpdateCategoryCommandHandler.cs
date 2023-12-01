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
            var updateCategory = _context.Categories.Where(x => x.Id == request.Id).FirstOrDefault();

            if (updateCategory == null)
            {
                return null;
            }

            updateCategory.Name = request.Name;
            //_context.Categories.Update(updateCategory);

            await _context.SaveChangesAsync();

            return ResponseDto<NoContentDto>.Success(204);
        }
    }
}
