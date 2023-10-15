using FiGroup_WebApi.Aplicacion.Comandos;
using FiGroup_WebApi.Context;
using FiGroup_WebApi.Dtos;
using MediatR;

namespace FiGroup_WebApi.Aplicacion.Handlers
{
    public class CreateTaskEventHandler : IRequestHandler<CreateTaskCommand, TaskDto>
    {
        private readonly FiGroupContext _context;
        public CreateTaskEventHandler(FiGroupContext context)
        {
            _context = context;
        }
    
        public async Task<TaskDto> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _context.Task.Add(new Models.Task
                {
                    TaskName = command.TaskName,
                    Status = command.IsCompleted,
                });

                await _context.SaveChangesAsync();

                return new TaskDto
                {
                    Id = _context.Task.Local.Last().Id,
                    TaskName = command.TaskName,
                    Status = command.IsCompleted
                };
    
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
