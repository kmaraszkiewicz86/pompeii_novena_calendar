﻿namespace PompeiiNovenaCalendar.Domain.Database.Entities
{
    public class RosarySelection
    {
        public int Id { get; set; }
        public int RosaryTypeId { get; set; }
        public RosaryType RosaryType { get; set; } = default!;
        public int DayRecordId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
