using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PompeiiNovenaCalendar.Domain.Database.Entities;

namespace PompeiiNovenaCalendar.Infrastructure.Database.EntityTypeConfigurations
{
    public class RosaryTypeConfiguration : IEntityTypeConfiguration<RosaryType>
    {
        public void Configure(EntityTypeBuilder<RosaryType> builder)
        {
            builder.ToTable("RosaryTypes");

            builder.HasKey(rt => rt.Id);

            builder.Property(rt => rt.Id)
                .ValueGeneratedOnAdd();

            builder.Property(rt => rt.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                new RosaryType { Id = 1, Name = "Tajemnice radosne" },
                new RosaryType { Id = 2, Name = "Tajemnice bolesne" },
                new RosaryType { Id = 3, Name = "Tajemnice chwalebne" },
                new RosaryType { Id = 4, Name = "Tajemnice światła" }
            );
        }
    }
}
