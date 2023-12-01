using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Services.Core.Application.Dtos;
using Movies.Services.Core.Application.Dtos.Films;
using Movies.Services.Infrastructure.Persistence.CQRS.Queries.GetAll;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Handlers.QueryHandlers.GetAll
{
    public class GetAllFilmQueryHandler : IRequestHandler<GetAllFilmQuery, ResponseDto<List<FilmsDto>>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllFilmQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<FilmsDto>>> Handle(GetAllFilmQuery request, CancellationToken cancellationToken)
        {
            var film = await _context.Categories.ToListAsync();

            var filmDto = _mapper.Map<List<FilmsDto>>(film);

            return ResponseDto<List<FilmsDto>>.Success(filmDto, 200);
        }
    }
}
