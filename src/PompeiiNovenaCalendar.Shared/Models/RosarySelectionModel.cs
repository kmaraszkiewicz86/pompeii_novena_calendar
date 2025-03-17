namespace PompeiiNovenaCalendar.Domain.Models
{
    public class RosarySelectionModel
    {
        public string Id { get; set; }

        public int RossaryTypeId { get; set; }

        public int DayRecordId { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
    }
}
