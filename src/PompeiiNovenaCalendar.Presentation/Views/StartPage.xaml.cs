using PompeiiNovenaCalendar.Presentation.ViewModels;

namespace PompeiiNovenaCalendar.Presentation.Views;

public partial class StartPage : ContentPage
{
    private readonly StartViewModel _bindingContext;


    public StartPage(StartViewModel bindingContext)
	{
		InitializeComponent();
        BindingContext = _bindingContext = bindingContext;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        _bindingContext.PageLoadedCommand.Execute(null);
    }
}