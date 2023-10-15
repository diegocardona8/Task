using FiGroup_WebApi.Dtos;
using MediatR;


namespace FiGroup_WebApi.Aplicacion.Comandos
{
    public class GetTasksByStatusCommand : IRequest<List<TaskDto>>
    {
        public bool TaskStatus { get; set; }
    }
}