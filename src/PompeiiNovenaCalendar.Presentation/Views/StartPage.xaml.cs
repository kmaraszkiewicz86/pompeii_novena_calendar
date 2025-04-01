using PompeiiNovenaCalendar.Presentation.ViewModels;

namespace PompeiiNovenaCalendar.Presentation.Views;

public partial class StartPage : ContentPage
{
    public StartPage(StartViewModel bindingContext)
	{
		InitializeComponent();
        BindingContext = bindingContext;
    }
}