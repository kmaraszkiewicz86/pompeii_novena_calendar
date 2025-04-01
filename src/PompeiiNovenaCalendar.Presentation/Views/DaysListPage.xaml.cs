using PompeiiNovenaCalendar.Domain.Models;
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

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && int.TryParse(checkBox.AutomationId, out int id))
        {
            DayRecordViewModel? day = _bindingContext.Days.FirstOrDefault(r => r.RosarySelections.Any(s => s.Id == id));

            if (day is null)
                return;

            RosarySelectionModel? rosarySelection = day.RosarySelections.FirstOrDefault(s => s.Id == id);

            if (rosarySelection is null)
                return;

            _bindingContext.ToogleRossarySelectionCommand.Execute(rosarySelection);
        }
    }
}