using Microsoft.EntityFrameworkCore;

namespace FiGroup_WebApi.Context
{
    public class FiGroupContext : DbContext
    {
        public FiGroupContext(DbContextOptions<FiGroupContext> options) : base(options)
        {
             
        }

        public DbSet<Models.Task> Task { get; set; }
    }
}
