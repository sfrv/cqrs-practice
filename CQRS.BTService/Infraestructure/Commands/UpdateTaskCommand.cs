using CQRS.Application.DTOs;
using MediatR;

namespace CQRS.Infraestructure.Commands
{
    public record UpdateTaskCommand(
        int Id, 
        string Title,
        string Description,
        bool IsCompleted
    ) : IRequest<TaskItemDto>;
}
