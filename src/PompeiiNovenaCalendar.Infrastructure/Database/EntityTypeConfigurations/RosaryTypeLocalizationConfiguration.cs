using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PompeiiNovenaCalendar.Domain.Database.Entities;

namespace PompeiiNovenaCalendar.Infrastructure.Database.EntityTypeConfigurations
{
    public class RosaryTypeLocalizationConfiguration : IEntityTypeConfiguration<RosaryTypeLocalization>
    {
        public void Configure(EntityTypeBuilder<RosaryTypeLocalization> builder)
        {
            builder.ToTable("RosaryTypeLocalizations");

            builder.HasKey(rt => rt.Id);

            builder.Property(rt => rt.Id)
                .ValueGeneratedOnAdd();

            builder.Property(rt => rt.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                new RosaryTypeLocalization { Id = 1, Name = "Tajemnice radosne" },
                new RosaryTypeLocalization { Id = 2, Name = "Tajemnice bolesne" },
                new RosaryTypeLocalization { Id = 3, Name = "Tajemnice chwalebne" },
                new RosaryTypeLocalization { Id = 4, Name = "Tajemnice światła" }
            );
        }
    }
}
