using AutoMapper;
using MediatR;
using Movies.Services.Core.Application.Dtos.Films;
using Movies.Services.Core.Application.Dtos.Movies;
using Movies.Services.Infrastructure.Persistence.CQRS.Queries.GetAll;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Handlers.QueryHandlers.GetAll
{
    public class GetAllMovieQueryHandler : IRequestHandler<GetAllMovieQuery, ResponseDto<List<MoviesDto>>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllMovieQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<MoviesDto>>> Handle(GetAllMovieQuery request, CancellationToken cancellationToken)
        {
            var movie = _context.Categories.FirstOrDefault();

            var movieDto = _mapper.Map<List<MoviesDto>>(movie);

            return ResponseDto<List<MoviesDto>>.Success(movieDto, 200);
        }
    }
}
