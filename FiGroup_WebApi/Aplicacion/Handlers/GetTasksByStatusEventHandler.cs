using AutoMapper;
using FiGroup_WebApi.Aplicacion.Comandos;
using FiGroup_WebApi.Context;
using FiGroup_WebApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FiGroup_WebApi.Aplicacion.Handlers
{
    public class GetTasksByStatusEventHandler : IRequestHandler<GetTasksByStatusCommand, List<TaskDto>>
    {
        private readonly FiGroupContext _context;
        private readonly IMapper _mapper;
        public GetTasksByStatusEventHandler(FiGroupContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TaskDto>> Handle(GetTasksByStatusCommand command, CancellationToken cancellationToken)
        {
            var tasks =  await _context
                                .Task
                                .Where(c => c.Status == command.TaskStatus)
                                .ToListAsync();

            if (tasks == null)
            { return null; }

            var taskDto = _mapper.Map<List<Models.Task>, List<TaskDto>>(tasks);
            return taskDto;
        }
    }
}
