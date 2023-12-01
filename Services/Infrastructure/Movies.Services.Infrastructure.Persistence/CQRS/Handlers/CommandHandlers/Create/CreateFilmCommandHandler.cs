using MediatR;
using Movies.Services.Core.Application.Dtos.Films;
using Movies.Services.Core.Domain.Common;
using Movies.Services.Core.Domain.Entities;
using Movies.Services.Infrastructure.Persistence.CQRS.Commands.Create;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Handlers.CommandHandlers.Create
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommand, ResponseDto<FilmsDto>>
    {
        private readonly AppDbContext _context;

        public CreateFilmCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<FilmsDto>> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            Films newFilm = new Films();
            _context.Films.AddAsync(new()
            {
                Name = request.Name,
                AgeLimit = request.AgeLimit,
                Duration = request.Duration,
                CategoriesId = request.CategoriesId,
                Contents = request.Contents,
                CreatedTime = DateTime.Now
            }); ;

            await _context.SaveChangesAsync();

            return ResponseDto<FilmsDto>.Success(new FilmsDto { Id = newFilm.Id }, 201);
        }
    }
}
