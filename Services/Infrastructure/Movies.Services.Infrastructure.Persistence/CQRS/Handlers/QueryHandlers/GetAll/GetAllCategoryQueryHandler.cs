using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Services.Core.Application.Dtos;
using Movies.Services.Infrastructure.Persistence.CQRS.Queries.GetAll;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Handlers.QueryHandlers.GetAll
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, ResponseDto<List<CategoriesDto>>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<CategoriesDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.ToListAsync();

            var categoryDto = _mapper.Map<List<CategoriesDto>>(category);

            return ResponseDto<List<CategoriesDto>>.Success(categoryDto, 200);
        }
    }
}
