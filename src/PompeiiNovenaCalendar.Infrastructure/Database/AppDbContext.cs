using Microsoft.EntityFrameworkCore;
using PompeiiNovenaCalendar.Domain.Entities;

namespace PompeiiNovenaCalendar.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<DayRecord> DayRecords { get; set; }
        public DbSet<RosaryType> RosaryTypes { get; set; }
        public DbSet<RosarySelection> RosarySelections { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
