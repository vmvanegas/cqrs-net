using CQRS.PRACTICO.Application.DTOs;
using MediatR;

namespace CQRS.PRACTICO.Infrastructure.Commands
{
    public record CreateTaskCommand(string Title, string Description) : IRequest<TaskItemDto>;
}
