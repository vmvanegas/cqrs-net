using CQRS.PRACTICO.Application.DTOs;
using MediatR;

namespace CQRS.PRACTICO.Infrastructure.Queries
{
    public record GetAllTasksQuery : IRequest<IEnumerable<TaskItemDto>>;
}
