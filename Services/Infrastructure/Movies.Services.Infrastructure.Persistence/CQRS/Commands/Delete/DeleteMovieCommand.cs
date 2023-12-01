using MediatR;
using Movies.Services.Core.Application.Dtos.Movies;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Commands.Delete
{
    public  class DeleteMovieCommand : IRequest<ResponseDto<MoviesDto>> //response
    {
        //requestler
        public int Id { get; set; }
    }
}
