using MediatR;
using Movies.Services.Core.Application.Dtos;
using Movies.Services.Core.Domain.Entities;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Commands.Create
{
    public class CreateCategoryCommand : IRequest<ResponseDto<CategoriesDto>> // response
    {
        //requestler
        public string Name { get; set; }
    }
}
