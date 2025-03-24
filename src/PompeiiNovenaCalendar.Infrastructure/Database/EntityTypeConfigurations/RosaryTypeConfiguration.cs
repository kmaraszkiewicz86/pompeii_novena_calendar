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

            builder.HasData(
                new RosaryType { Id = 1, Key = "JoyfulMysteries" },
                new RosaryType { Id = 2, Key = "SorrowfulMysteries" },
                new RosaryType { Id = 3, Key = "GloriousMysteries" },
                new RosaryType { Id = 4, Key = "LuminousMysteries" }
            );
        }
    }
}
