using CQRS.Application.DTOs;
using CQRS.Domain;
using CQRS.Infraestructure;
using CQRS.Infraestructure.Commands;
using MediatR;

namespace CQRS.Application.Handlers
{
    public class CreateTaskHandler 
        : IRequestHandler<CreateTaskCommand, TaskItemDto>
    {
        private readonly ApplicationDBContext _dbContext;

        public CreateTaskHandler(ApplicationDBContext dBContext)
        { 
            _dbContext = dBContext;
        }

        public async Task<TaskItemDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
            };
            _dbContext.Add(taskItem);
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
