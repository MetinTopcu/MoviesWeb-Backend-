using AutoMapper;
using MediatR;
using Movies.Services.Core.Application.Dtos;
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
        private readonly IMapper _mapper;

        public CreateMovieCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<MoviesDto>> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var contentDto = _mapper.Map<Contents>(request.Contents);

            Movie newMovie = new Movie();
            newMovie.Name = request.Name;
            newMovie.AgeLimit = request.AgeLimit;
            newMovie.Duration = request.Duration;
            newMovie.Episode  = request.Episode;
            newMovie.Season = request.Season;
            newMovie.CategoriesId = request.CategoriesId;
            newMovie.Contents = contentDto;
            //newMovie.CreatedTime = DateTime.Now;

            //request.Categories

            //var newCategoriesItem = new Categories();
            //newCategoriesItem.Id = request.CategoriesId;
            //int categoriesId = newCategoriesItem.Id;
            //newMovie.Categories.Name = newCategoriesItem.Name;


            //var newCategories = new Categories { Id = request.CategoriesId };
            //newMovie.Categories.Id = newCategories.Id;


            await _context.Movies.AddAsync(newMovie);

            await _context.SaveChangesAsync();

            var movieDto = _mapper.Map<MoviesDto>(newMovie);

            return ResponseDto<MoviesDto>.Success(movieDto, 201);
        }
    }
}
