using MediatR;
using Movies.Services.Core.Application.Dtos;
using Movies.Services.Core.Application.Dtos.Movies;
using Movies.Services.Core.Domain.Entities;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Commands.Update
{
    public class UpdateMovieCommand : IRequest<ResponseDto<NoContentDto>>
    {
        //requestler
        public int Id { get; set; }
        public string Name { get; set; }
        public int AgeLimit { get; set; }
        public int Duration { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; } // bölüm
        public int CategoriesId { get; set; }
        public Contents Contents { get; set; }
    }
}
