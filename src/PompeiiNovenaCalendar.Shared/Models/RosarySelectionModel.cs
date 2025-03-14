namespace PompeiiNovenaCalendar.Domain.Models
{
    public class RosarySelectionModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
    }
}
