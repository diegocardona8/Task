using AutoMapper;
using FiGroup_WebApi.Aplicacion.Comandos;
using FiGroup_WebApi.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FiGroup_WebApi.Aplicacion.Handlers
{
    public class DeleteTaskEventHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly FiGroupContext _context;
        private readonly IMapper _mapper;
        public DeleteTaskEventHandler(FiGroupContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool>Handle(DeleteTaskCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var taskToDelete = await _context.Task
                                                   .FirstOrDefaultAsync(c => c.Id == command.TaskId);

                if (taskToDelete == null)
                { return false; }

                _context.Remove(taskToDelete);
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
