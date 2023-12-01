using MediatR;
using Movies.Services.Core.Application.Dtos.Movies;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Queries.GetAll
{
    public class GetAllMovieQuery : IRequest<ResponseDto<List<MoviesDto>>>
    {

    }
}
