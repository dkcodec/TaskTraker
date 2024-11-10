using Microsoft.EntityFrameworkCore;

namespace TaskTrackerAPI.Data
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options) { }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
