using PompeiiNovenaCalendar.Presentation.Views;

namespace PompeiiNovenaCalendar
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(StartPage), typeof(StartPage));
            Routing.RegisterRoute(nameof(DaysListPage), typeof(DaysListPage));
        }
    }
}
