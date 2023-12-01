using MediatR;
using Movies.Services.Core.Application.Dtos.Films;
using Movies.Services.Core.Domain.Entities;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Commands.Update
{
    public class UpdateFilmCommand : IRequest<ResponseDto<FilmsDto>> //response
    {
        //requestler
        public int Id { get; set; }
        public string Name { get; set; }
        public int AgeLimit { get; set; }
        public int Duration { get; set; }
        public int CategoriesId { get; set; }
        public List<Contents> Contents { get; set; }
    }
}
