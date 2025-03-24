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

            builder.Property(rt => rt.Language)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                new RosaryTypeLocalization { Id = 1, Key = "JoyfulMysteries", Name = "Tajemnice radosne", Language = "pl" },
                new RosaryTypeLocalization { Id = 2, Key = "SorrowfulMysteries", Name = "Tajemnice bolesne", Language = "pl" },
                new RosaryTypeLocalization { Id = 3, Key = "GloriousMysteries", Name = "Tajemnice chwalebne", Language = "pl" },
                new RosaryTypeLocalization { Id = 4, Key = "LuminousMysteries", Name = "Tajemnice światła", Language = "pl" },
                new RosaryTypeLocalization { Id = 5, Key = "JoyfulMysteries", Name = "Joyful Mysteries", Language = "en" },
                new RosaryTypeLocalization { Id = 6, Key = "SorrowfulMysteries", Name = "Sorrowful Mysteries", Language = "en" },
                new RosaryTypeLocalization { Id = 7, Key = "LuminousMysteries", Name = "Glorious Mysteries", Language = "en" },
                new RosaryTypeLocalization { Id = 8, Key = "SorrowfulMysteries", Name = "Luminous Mysteries", Language = "en" }
            );
        }
    }
}
