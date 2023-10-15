using AutoMapper;
using FiGroup_WebApi.Aplicacion.Commands;
using FiGroup_WebApi.Context;
using FiGroup_WebApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FiGroup_WebApi.Aplicacion.Handlers
{
    public class GetTaskEventHandler : IRequestHandler<GetTasksCommand, List<TaskDto>>
    {
        private readonly FiGroupContext _context;
        private readonly IMapper _mapper;
        public GetTaskEventHandler(FiGroupContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TaskDto>> Handle(GetTasksCommand command, CancellationToken cancellationToken)
        {
            var tasks = await _context.Task.ToListAsync();
            var taskDto = _mapper.Map<List<Models.Task>, List<TaskDto>>(tasks);
            return taskDto;
        }
    }
}
   