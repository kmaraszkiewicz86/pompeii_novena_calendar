namespace PompeiiNovenaCalendar.Domain.Models
{
    public class DayRecordModel
    {
        public DayRecordModel(int id, DateTime day)
        {
            Id = id;
            Day = day;
        }

        public int Id { get; set; }

        public DateTime Day { get; set; }

        public string StatusName => IsCompleted ? "Wykonany" : "Niewykonany"; //change it to icon

        public bool[] MysteriesStatus { get; private set; } = new bool[4];

        public bool IsCompleted => MysteriesStatus.Take(3).Count(status => status) >= 3;

        public bool CanEdit() => Day <= DateTime.Today;

        public void SetMysteryStatus(int index, bool value)
        {
            if (CanEdit() && index >= 0 && index < MysteriesStatus.Length)
                MysteriesStatus[index] = value;
        }
    }
}
