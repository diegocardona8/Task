using System.ComponentModel.DataAnnotations;

namespace FiGroup_WebApi.Models
{
    public class TaskStatus
    {
        [Key]
        public int? IdEstado { get; set; }
        public string NombreEstado { get; set; }

        //public virtual ICollection<Tareas> Tareas { get; set; }
    }
}
