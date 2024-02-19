using CQRS.PRACTICO.Application.DTOs;
using MediatR;

namespace CQRS.PRACTICO.Infrastructure.Queries
{
    public record GetTaskByIdQuery(int Id) : IRequest<TaskItemDto>;
}
