namespace PompeiiNovenaCalendar.Domain.Models
{
    public class DayRecordModel(int Id, DateTime Date)
    {
        public bool[] MysteriesStatus { get; private set; } = new bool[4];

        public bool IsCompleted => MysteriesStatus.Take(3).Count(status => status) >= 3;

        public bool CanEdit() => Date <= DateTime.Today;

        public void SetMysteryStatus(int index, bool value)
        {
            if (CanEdit() && index >= 0 && index < MysteriesStatus.Length)
                MysteriesStatus[index] = value;
        }
    }
}
