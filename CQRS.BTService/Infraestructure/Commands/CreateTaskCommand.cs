using CQRS.Application.DTOs;
using MediatR;

namespace CQRS.Infraestructure.Commands
{
    public record CreateTaskCommand(
        string Title, 
        string Description
    ) : IRequest<TaskItemDto>;
}
