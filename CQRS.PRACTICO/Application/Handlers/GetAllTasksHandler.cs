using CQRS.PRACTICO.Application.DTOs;
using CQRS.PRACTICO.Domain;
using CQRS.PRACTICO.Infrastructure;
using CQRS.PRACTICO.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.PRACTICO.Application.Handlers
{
    public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskItemDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAllTasksHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TaskItemDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _dbContext.TaskItems.ToListAsync(cancellationToken);

            return tasks.Select(task => new TaskItemDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
            });
        }
    }
}
