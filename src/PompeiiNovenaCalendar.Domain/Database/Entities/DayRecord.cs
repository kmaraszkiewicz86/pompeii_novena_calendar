namespace PompeiiNovenaCalendar.Domain.Database.Entities
{
    public class DayRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<RosarySelection> RosarySelections { get; set; } = [];
        public bool IsCompleted { get; set; }
    }
}
