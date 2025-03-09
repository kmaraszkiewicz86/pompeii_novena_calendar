using PompeiiNovenaCalendar.Presentation.Views;

namespace PompeiiNovenaCalendar
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DaysListPage), typeof(DaysListPage));
        }
    }
}
