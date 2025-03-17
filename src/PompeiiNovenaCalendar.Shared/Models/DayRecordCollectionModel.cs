namespace PompeiiNovenaCalendar.Domain.Models
{
    public class DayRecordCollectionModel
    {
        public int Id { get; set; }

        public DateTime Day { get; set; }

        public string StatusName => IsCompleted ? "Wykonany" : "Niewykonany"; //change it to icon

        public HashSet<RosarySelectionModel> RosarySelections { get; set; } = [];

        public bool IsCompleted { get; set; }
    }
}
