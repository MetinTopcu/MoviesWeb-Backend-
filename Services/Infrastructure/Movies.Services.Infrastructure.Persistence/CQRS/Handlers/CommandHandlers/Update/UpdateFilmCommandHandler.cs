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
            var updateFilm = _context.Films.Where(x => x.Id == request.Id).FirstOrDefault();


            if (updateFilm == null)
            {
                return null;
            }

            updateFilm.Name = request.Name;
            updateFilm.AgeLimit = request.AgeLimit;
            updateFilm.Duration = request.Duration;
            updateFilm.CategoriesId = request.CategoriesId;
            updateFilm.Contents = request.Contents;

            //_context.Films.Update(updateFilm);


            await _context.SaveChangesAsync();

            return ResponseDto<NoContentDto>.Success(204);
        }
    }
}
