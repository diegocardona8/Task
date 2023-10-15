using System.ComponentModel.DataAnnotations;

namespace FiGroup_WebApi.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string TaskName { get; set; }
        public bool Status { get; set; }
    }
}
