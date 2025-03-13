using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PompeiiNovenaCalendar.Domain.Database.Entities;

namespace PompeiiNovenaCalendar.Infrastructure.Database.EntityTypeConfigurations
{
    public class DayRecordConfiguration : IEntityTypeConfiguration<DayRecord>
    {
        public void Configure(EntityTypeBuilder<DayRecord> builder)
        {
            builder.ToTable("DayRecords");
            builder.HasKey(dr => dr.Id);
            builder.Property(dr => dr.Id).ValueGeneratedOnAdd();
            builder.Property(dr => dr.Date).IsRequired();
            builder.Property(dr => dr.IsCompleted).IsRequired();
        }
    }
}
