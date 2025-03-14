using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using PompeiiNovenaCalendar.Domain.Models;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Queries;

namespace PompeiiNovenaCalendar.Presentation.ViewModels
{
    public class DayListViewModel(IMediator mediator) : ObservableObject
    {
        private ObservableCollection<DayRecordModel> _days = new();

        public ObservableCollection<DayRecordModel> Days
        {
            get => _days;
            set => SetProperty(ref _days, value);
        }

        public IRelayCommand<DayRecordModel> SaveCommand => new AsyncRelayCommand<DayRecordModel>(ToogleRossarySelectionAsync!);
        public IRelayCommand LoadCommand => new AsyncRelayCommand(LoadDaysAsync);

        private async Task LoadDaysAsync()
        {
            IEnumerable<DayRecordModel> days = await mediator.Send(new GetAllDayRecordsAsyncQuery());

            foreach (DayRecordModel day in days) 
            {
                Days.Add(day);
            }
        }

        private async Task ToogleRossarySelectionAsync(DayRecordModel record)
        {
            await mediator.Send(new SaveRosarySelectionCommand(record.Id, 1, true));
            await LoadDaysAsync();
        }
    }
}
