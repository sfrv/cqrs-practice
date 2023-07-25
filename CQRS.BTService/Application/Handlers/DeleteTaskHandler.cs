using CQRS.Infraestructure;
using CQRS.Infraestructure.Commands;
using MediatR;

namespace CQRS.Application.Handlers
{
    public class DeleteTaskHandler
        : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ApplicationDBContext _dbContext;

        public DeleteTaskHandler(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _dbContext.TaskItems.FindAsync(
                new object[] { request.Id }, cancellationToken);

            if (taskItem == null)
            {
                return false;
            }
            _dbContext.TaskItems.Remove(taskItem);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
