using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;

        public CreateFilmCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<FilmsDto>> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            var contentDto = _mapper.Map<Contents>(request.Contents);

            Films newFilm = new Films();
            newFilm.Name = request.Name;
            newFilm.AgeLimit = request.AgeLimit;
            newFilm.Duration = request.Duration;
            newFilm.CategoriesId = request.CategoriesId;
            newFilm.Contents = contentDto;
            newFilm.Categories = await _context.Categories.Where(x => x.Id == request.CategoriesId).FirstOrDefaultAsync();
            //newFilm.CreatedTime = DateTime.Now;

            await _context.Films.AddAsync(newFilm);

            //await _context.Films.AddAsync(new() // newFilm kullanmadan da veri aktarabileceğimiz bir yöntem
            //{
            //    Name = request.Name,
            //    AgeLimit = request.AgeLimit,
            //    Duration = request.Duration,
            //    CategoriesId = request.CategoriesId,
            //    Contents = request.Contents,
            //    CreatedTime = DateTime.Now
            //}); ;

            await _context.SaveChangesAsync();

            var filmDto = _mapper.Map<FilmsDto>(newFilm);

            return ResponseDto<FilmsDto>.Success(filmDto, 201);
        }
    }
}
