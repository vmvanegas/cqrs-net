using MediatR;

namespace CQRS.PRACTICO.Infrastructure.Commands
{
    public record DeleteTaskCommand(int Id) : IRequest<bool>;
}
