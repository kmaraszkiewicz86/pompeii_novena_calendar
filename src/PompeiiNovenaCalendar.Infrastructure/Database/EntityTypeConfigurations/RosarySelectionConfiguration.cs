using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PompeiiNovenaCalendar.Domain.Database.Entities;

namespace PompeiiNovenaCalendar.Infrastructure.Database.EntityTypeConfigurations
{
    public class RosarySelectionConfiguration : IEntityTypeConfiguration<RosarySelection>
    {
        public void Configure(EntityTypeBuilder<RosarySelection> builder)
        {
            builder.ToTable("RosarySelections");
            builder.HasKey(rs => rs.Id);
            builder.Property(rs => rs.Id).ValueGeneratedOnAdd();
            builder.Property(rs => rs.IsCompleted).IsRequired();

            builder.HasOne<RosaryType>()
                .WithMany()
                .HasForeignKey(rs => rs.RosaryTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<DayRecord>()
                .WithMany(dr => dr.RosarySelections)
                .HasForeignKey(rs => rs.DayRecordId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
