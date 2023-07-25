using CQRS.Application.DTOs;
using CQRS.Infraestructure;
using CQRS.Infraestructure.Queries;
using MediatR;

namespace CQRS.Application.Handlers
{
    public class GetTaskByIdHandler
        : IRequestHandler<GetTaskByIdQuery, TaskItemDto>
    {
        private readonly ApplicationDBContext _dbContext;

        public GetTaskByIdHandler(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<TaskItemDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var taskItem = await _dbContext.TaskItems.FindAsync(
                new object[] { request.Id }, cancellationToken);

            if (taskItem == null)
            {
                return null;
            }

            return new TaskItemDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted,
            };
        }
    }
}
