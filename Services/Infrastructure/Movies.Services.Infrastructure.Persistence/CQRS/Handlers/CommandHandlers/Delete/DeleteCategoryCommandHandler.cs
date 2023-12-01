using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Services.Infrastructure.Persistence.CQRS.Commands.Delete;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Handlers.CommandHandlers.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ResponseDto<NoContentDto>>
    {
        private readonly AppDbContext _context;

        public DeleteCategoryCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var deleteCategory = await _context.Categories.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (deleteCategory == null)
            {
                return null;
            }
            _context.Categories.Remove(deleteCategory);

            await _context.SaveChangesAsync();

            return ResponseDto<NoContentDto>.Success(204);
        }
    }
}
