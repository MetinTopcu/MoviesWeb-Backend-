using AutoMapper;
using AutoMapper.Internal.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Services.Core.Application.Dtos.Films;
using Movies.Services.Infrastructure.Persistence.CQRS.Queries.GetById;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Handlers.QueryHandlers.GetById
{
    public class GetFilmByIdQueryHandler : IRequestHandler<GetByIdFilmQuery, ResponseDto<FilmsDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetFilmByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<FilmsDto>> Handle(GetByIdFilmQuery request, CancellationToken cancellationToken)
        {
            var films = _context.Films.FirstOrDefault(x => x.Id == request.Id);

            var filmsDto = _mapper.Map<FilmsDto>(films);

            return ResponseDto<FilmsDto>.Success(filmsDto, 200);
        }
    }
}
