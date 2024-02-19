using CQRS.PRACTICO.Application.DTOs;
using MediatR;

namespace CQRS.PRACTICO.Infrastructure.Commands
{
    public record UpdateTaskCommand(int Id, string Title, string Description, bool IsCompleted) : IRequest<TaskItemDto>;
}
