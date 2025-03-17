namespace PompeiiNovenaCalendar.Domain.Models
{
    public class DayRecordModel
    {
        public int Id { get; set; }

        public DateTime Day { get; set; }

        public int RossarySelectionId { get; set; }

        public string RossaryTypeName { get; set; } = string.Empty;

        public bool IsRossarySelectionCompleted { get; set; }

        public bool IsDayCompleted { get; set; }
    }
}
