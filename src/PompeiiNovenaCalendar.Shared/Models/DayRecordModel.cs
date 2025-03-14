namespace PompeiiNovenaCalendar.Domain.Models
{
    public class DayRecordModel
    {
        public int Id { get; set; }

        public DateTime Day { get; set; }

        public string StatusName => IsCompleted ? "Wykonany" : "Niewykonany"; //change it to icon

        public RosarySelectionModel[] RosarySelections { get; set; } = default!;

        public bool IsCompleted { get; set; }
    }
}
