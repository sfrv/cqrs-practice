using CQRS.Application.DTOs;
using CQRS.Infraestructure;
using CQRS.Infraestructure.Commands;
using MediatR;

namespace CQRS.Application.Handlers
{
    public class UpdateTaskHandler
        : IRequestHandler<UpdateTaskCommand, TaskItemDto>
    {
        private readonly ApplicationDBContext _dbContext;

        public UpdateTaskHandler(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<TaskItemDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _dbContext.TaskItems.FindAsync(
                new object[] { request.Id }, cancellationToken);
            
            if (taskItem == null)
            {
                return null;
            }

            taskItem.Title = request.Title;
            taskItem.Description = request.Description;
            taskItem.IsCompleted = request.IsCompleted;
            await _dbContext.SaveChangesAsync(cancellationToken);

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
