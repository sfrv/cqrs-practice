using CQRS.Application.DTOs;
using MediatR;

namespace CQRS.Infraestructure.Queries
{
    public record GetAllTaskQuery : IRequest<IEnumerable<TaskItemDto>>;
}
