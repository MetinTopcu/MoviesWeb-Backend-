using MediatR;
using Movies.Services.Core.Application.Dtos.Films;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Queries.GetAll
{
    public class GetAllFilmQuery : IRequest<ResponseDto<FilmsDto>>
    {
    }
}
