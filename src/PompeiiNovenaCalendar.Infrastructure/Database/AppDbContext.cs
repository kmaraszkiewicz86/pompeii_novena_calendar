using Microsoft.EntityFrameworkCore;
using PompeiiNovenaCalendar.Domain.Database.Entities;

namespace PompeiiNovenaCalendar.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<DayRecord> DayRecords { get; set; }
        public DbSet<RosaryType> RosaryTypes { get; set; }
        public DbSet<RosarySelection> RosarySelections { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
