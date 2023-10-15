using AutoMapper;
using FiGroup_WebApi.Aplicacion.Comandos;
using FiGroup_WebApi.Aplicacion.Commands;
using FiGroup_WebApi.Context;
using FiGroup_WebApi.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FiGroup_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly FiGroupContext _dbcontext;
        private readonly IMapper _mapper;

        public TaskController(FiGroupContext _context, IMediator mediator,IMapper mapper)
        {
            _dbcontext = _context;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetTask")]
        public async Task<ActionResult<List<TaskDto>>> GetTask()
        {
            var task = await _mediator.Send(new GetTasksCommand());
            return Ok(task);
        }

        [HttpGet]
        [Route("GetTasksByStatus/{status}")]
        public async Task<ActionResult<List<TaskDto>>> GetTasksByStatus(bool status)
        { 
            return await _mediator.Send(new GetTasksByStatusCommand { TaskStatus = status });
        }

        [HttpPost]
        [Route("AddTask")]
        public async Task<ActionResult<TaskDto>> AddTask([FromBody] CreateTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpPut]
        [Route("UpdateTask")]
        public async Task<ActionResult<bool>> UpdateTask([FromBody] UpdateTaskCommand command)
        
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeteleTask/{taskId}")]
        public async Task<ActionResult<bool>>EliminarTarea(int taskId)
        {
            var result = await _mediator.Send(new DeleteTaskCommand { TaskId = taskId });

            return Ok(result); 
        }
    }
}
