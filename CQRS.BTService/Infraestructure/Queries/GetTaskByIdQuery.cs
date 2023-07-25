using CQRS.Application.DTOs;
using MediatR;

namespace CQRS.Infraestructure.Queries
{
    public record GetTaskByIdQuery(
        int Id    
    ) : IRequest<TaskItemDto>;
}
