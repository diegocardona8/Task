using FiGroup_WebApi.Dtos;
using MediatR;
using System.ComponentModel;

namespace FiGroup_WebApi.Aplicacion.Comandos
{
    public class CreateTaskCommand : IRequest<TaskDto>
    {
        public string TaskName { get; set; }
        [DefaultValue(false)]
        public bool IsCompleted { get; set; } = false;
    }
}
