namespace PompeiiNovenaCalendar.Domain.Repositories
{
    public interface IRosarySelectionRepository
    {
        Task ToogleRossarySelectionAsync(SaveRosarySelectionCommand command);
    }
}
