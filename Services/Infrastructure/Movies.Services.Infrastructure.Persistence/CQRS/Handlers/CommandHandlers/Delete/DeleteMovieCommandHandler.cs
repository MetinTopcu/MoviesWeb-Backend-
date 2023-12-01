using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Services.Core.Domain.Entities;
using Movies.Services.Infrastructure.Persistence.CQRS.Commands.Delete;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Handlers.CommandHandlers.Delete
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, ResponseDto<NoContentDto>>
    {
        private readonly AppDbContext _context;

        public DeleteMovieCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var deleteMovie = await _context.Movies.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (deleteMovie == null)
            {
                return null;
            }

            _context.Movies.Remove(deleteMovie);
            await _context.SaveChangesAsync();

            return ResponseDto<NoContentDto>.Success(204);
        }
    }
}
