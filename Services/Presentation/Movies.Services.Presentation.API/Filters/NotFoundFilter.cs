using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Movies.Services.Core.Domain.Common;
using Movies.Services.Infrastructure.Persistence;
using Movies.Shared.Dtos;

namespace Movies.Services.Presentation.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public NotFoundFilter(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if(idValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;
            var anyEntity = await _dbSet.AnyAsync(x => x.Id == id);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(ResponseDto<NoContentDto>.Fail($"{typeof(T).Name}({id}) not found", 404));

        }
    }
}
