namespace PompeiiNovenaCalendar.Domain.Database.Entities
{
    public class RosaryTypeLocalization
    {
        public int Id { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
    }
}
