using MediatR;
using Movies.Services.Core.Application.Dtos;
using Movies.Services.Core.Domain.Entities;
using Movies.Services.Infrastructure.Persistence.CQRS.Commands.Create;
using Movies.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.CQRS.Handlers.CommandHandlers.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ResponseDto<CategoriesDto>>
    {
        private readonly AppDbContext _context;

        public CreateCategoryCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<CategoriesDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Categories newCategories = new Categories();
            newCategories.Name = request.Name;

            await _context.Categories.AddAsync(newCategories);

            await _context.SaveChangesAsync();
            // örnek olsun diye burada data'yı mapper'lamadım new CategoriesDto { Id = newCategories.Id, Name = newCategories.Name } 
            return ResponseDto<CategoriesDto>.Success(new CategoriesDto { Id = newCategories.Id, Name = newCategories.Name }, 201);
        }
    }
}
