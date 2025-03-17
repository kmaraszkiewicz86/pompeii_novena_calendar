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
        private int _daysLengthToEnd = 0;

        public int DaysLengthToEnd
        {
            get => _daysLengthToEnd;
            set
            {
                SetProperty(ref _daysLengthToEnd, value);
                OnPropertyChanged(nameof(DaysLengthToEndText));
            }
        }

        public string DaysLengthToEndText => $"Pozostało {DaysLengthToEnd} dni do końca";

        private ObservableCollection<DayRecordCollectionModel> _days = new();

        public ObservableCollection<DayRecordCollectionModel> Days
        {
            get => _days;
            set => SetProperty(ref _days, value);
        }

        public IRelayCommand<DayRecordModel> SaveCommand => new AsyncRelayCommand<DayRecordModel>(ToogleRossarySelectionAsync!);
        public IRelayCommand LoadCommand => new AsyncRelayCommand(LoadDaysAsync);
        public IRelayCommand GetDaysLengthToEndCommand => new AsyncRelayCommand(GetDaysLengthToEndAsync);

        private async Task LoadDaysAsync()
        {
            IEnumerable<DayRecordCollectionModel> days = await mediator.Send(new GetAllDayRecordsAsyncQuery());

            foreach (DayRecordCollectionModel day in days) 
            {
                Days.Add(day);
            }
        }

        private async Task ToogleRossarySelectionAsync(DayRecordModel record)
        {
            await mediator.Send(new SaveRosarySelectionCommand(record.Id, 1, true));
            await GetDaysLengthToEndAsync();
            await LoadDaysAsync();
        }

        private async Task GetDaysLengthToEndAsync()
        {
            DaysLengthToEnd = await mediator.Send(new GetDaysLengthToEndQuery());
        }
    }
}
