using Microsoft.EntityFrameworkCore;
using Stafferable.Shared.Auth;
using Stafferable.Shared.Timesheet;

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
    }
}