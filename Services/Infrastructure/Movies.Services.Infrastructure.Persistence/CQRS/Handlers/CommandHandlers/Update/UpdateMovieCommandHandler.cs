using MediatR;
using Movies.Services.Infrastructure.Persistence.CQRS.Commands.Update;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Handlers.CommandHandlers.Update
{
    public class UpdateMovieCommandHandler: IRequestHandler<UpdateMovieCommand, ResponseDto<NoContentDto>>
    {
        private readonly AppDbContext _context;

        public UpdateMovieCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<NoContentDto>> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var updateMovie = _context.Movies.Where(x => x.Id == request.Id).FirstOrDefault();

            if (updateMovie == null)
            {
                return null;
            }

            updateMovie.Name = request.Name;
            updateMovie.AgeLimit = request.AgeLimit;
            updateMovie.Duration = request.Duration;
            updateMovie.CategoriesId = request.CategoriesId;
            updateMovie.Contents = request.Contents;

            //_context.Movies.Update(updateMovie);

            await _context.SaveChangesAsync();

            return ResponseDto<NoContentDto>.Success(204);
        }
    }
}
