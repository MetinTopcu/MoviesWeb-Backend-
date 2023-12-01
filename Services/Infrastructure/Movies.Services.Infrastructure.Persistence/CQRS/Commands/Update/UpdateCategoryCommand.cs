using MediatR;
using Movies.Services.Core.Application.Dtos;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<ResponseDto<NoContentDto>>
    {

        //requestler
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
