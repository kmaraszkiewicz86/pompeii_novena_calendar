using PompeiiNovenaCalendar.Presentation.ViewModels;

namespace PompeiiNovenaCalendar.Presentation.Views;

public partial class DaysListPage : ContentPage
{
    private readonly DayListViewModel _bindingContext;

    public DaysListPage(DayListViewModel bindingContext)
	{
		InitializeComponent();
        BindingContext = _bindingContext = bindingContext;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        _bindingContext.LoadCommand.Execute(null);
    }
}