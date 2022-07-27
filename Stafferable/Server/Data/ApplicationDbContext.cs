using Stafferable.Shared.Auth;

namespace Stafferable.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TimesheetCard> TimesheetCards { get; set; }
        public DbSet<TimesheetRecord> TimesheetRecords { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
    }
}