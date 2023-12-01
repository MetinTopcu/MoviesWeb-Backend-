using MediatR;
using Movies.Services.Core.Application.Dtos.Movies;
using Movies.Services.Core.Domain.Entities;
using Movies.Services.Infrastructure.Persistence.CQRS.Commands.Create;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Handlers.CommandHandlers.Create
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, ResponseDto<MoviesDto>>
    {
        private readonly AppDbContext _context;

        public CreateMovieCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<MoviesDto>> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            Movie newMovie = new Movie();
            _context.Movies.AddAsync(new()
            {
                Name = request.Name,
                AgeLimit = request.AgeLimit,
                Duration = request.Duration,
                Episode = request.Episode,
                Season = request.Season,
                CategoriesId = request.CategoriesId,
                Contents = request.Contents,
                CreatedTime = DateTime.Now  
            });

            await _context.SaveChangesAsync();

            return ResponseDto<MoviesDto>.Success(new MoviesDto { Id = newMovie.Id}, 201);
        }
    }
}
