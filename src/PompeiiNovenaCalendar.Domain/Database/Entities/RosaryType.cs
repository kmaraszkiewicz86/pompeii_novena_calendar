using PompeiiNovenaCalendar.Domain.Database.Entities;

namespace PompeiiNovenaCalendar.Domain.Database.Entities
{
    public class RosaryType
    {
        public int Id { get; set; }
        public RosaryTypeLocalization RosaryTypeLocalization { get; set; } = default!;
    }
}
