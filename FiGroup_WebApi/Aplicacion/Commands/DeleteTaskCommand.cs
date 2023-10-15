using FiGroup_WebApi.Dtos;
using MediatR;

namespace FiGroup_WebApi.Aplicacion.Comandos
{
    public class DeleteTaskCommand : IRequest<bool>
    {
        public int? TaskId { get; set; }
    }
}
