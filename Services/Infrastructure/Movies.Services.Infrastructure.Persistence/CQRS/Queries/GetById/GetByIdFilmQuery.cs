using MediatR;
using Movies.Services.Core.Application.Dtos.Films;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Queries.GetById
{
    public class GetByIdFilmQuery : IRequest<ResponseDto<FilmsDto>>
    {
        public int Id { get; set; }
    }
}
