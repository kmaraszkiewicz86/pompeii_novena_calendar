namespace PompeiiNovenaCalendar.Domain.Database
{
    public interface IAppDbQueryContext
    {
        Task<ISqliteConnectionConnection> CreateConnectionAsync();
    }
}
