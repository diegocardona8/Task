using MediatR;

namespace FiGroup_WebApi.Aplicacion.Comandos
{
    public class UpdateTaskCommand : IRequest<bool>
    {
        public int? TaskId { get; set; }
        public bool TaskStatus { get; set; }
    }
}