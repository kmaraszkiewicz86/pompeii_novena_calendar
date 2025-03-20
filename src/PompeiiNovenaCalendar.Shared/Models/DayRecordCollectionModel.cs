namespace PompeiiNovenaCalendar.Domain.Models
{
    public class DayRecordCollectionModel
    {
        public int Id { get; set; }

        public DateTime Day { get; set; }

        public HashSet<RosarySelectionModel> RosarySelections { get; set; } = [];

        public bool IsCompleted { get; set; }
    }
}
