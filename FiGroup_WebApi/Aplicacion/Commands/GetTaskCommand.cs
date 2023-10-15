using FiGroup_WebApi.Dtos;
using MediatR;

namespace FiGroup_WebApi.Aplicacion.Commands

{
    public class GetTasksCommand : IRequest<List<TaskDto>>
    {
    }
}
