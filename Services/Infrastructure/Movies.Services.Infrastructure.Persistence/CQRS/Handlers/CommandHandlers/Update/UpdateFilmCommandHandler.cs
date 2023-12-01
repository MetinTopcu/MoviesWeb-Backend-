using MediatR;
using Movies.Services.Core.Application.Dtos.Films;
using Movies.Services.Infrastructure.Persistence.CQRS.Commands.Update;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Handlers.CommandHandlers.Update
{
    public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommand, ResponseDto<NoContentDto>>
    {
        private readonly AppDbContext _context;

        public UpdateFilmCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
        {
            var updateFilm = _context.Films.FirstOrDefault(x => x.Id == request.Id);
            _context.Films.Update(new()
            {
                Name = request.Name,
                AgeLimit = request.AgeLimit,
                Duration = request.Duration,
                CategoriesId = request.CategoriesId,
                Contents = request.Contents
            });
            await _context.SaveChangesAsync();

            return ResponseDto<NoContentDto>.Success(204);
        }
    }
}
