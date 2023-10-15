using FiGroup_WebApi.Aplicacion.Comandos;
using FiGroup_WebApi.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FiGroup_WebApi.Aplicacion.Handlers
{
    public class UpdateTaskEventHandler : IRequestHandler <UpdateTaskCommand, bool>
    {
        private readonly FiGroupContext _context;
        public UpdateTaskEventHandler(FiGroupContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateTaskCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var taskToUpdated = await _context.Task.Where(x => x.Id == command.TaskId)
                                                       .FirstOrDefaultAsync();

                if (taskToUpdated != null)
                {
                    taskToUpdated.Status = command.TaskStatus;
                }
                else

                    throw new Exception($"The task doesn't exist");
                
                _context.Update(taskToUpdated);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
