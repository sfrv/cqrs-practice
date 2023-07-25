using MediatR;

namespace CQRS.Infraestructure.Commands
{
    public record DeleteTaskCommand(
        int Id
    ) : IRequest<bool>;
}
