using PompeiiNovenaCalendar.Presentation.ViewModels;

namespace PompeiiNovenaCalendar.Presentation.Views;

public partial class DaysListPage : ContentPage
{
	public DaysListPage(DayListViewModel bindingContext)
	{
		InitializeComponent();
        BindingContext = bindingContext;
    }
}