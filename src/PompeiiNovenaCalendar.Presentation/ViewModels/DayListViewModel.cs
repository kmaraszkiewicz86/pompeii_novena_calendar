using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using PompeiiNovenaCalendar.Domain.Models;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Presentation.ViewModels
{
    public class DayListViewModel(IMediator mediator) : ObservableObject
    {
        private const int NovennaDayLenght = 54;

        private ObservableCollection<DayRecordModel> _days = new();

        public ObservableCollection<DayRecordModel> Days
        {
            get => _days;
            set => SetProperty(ref _days, value);
        }

        public IRelayCommand<DayRecordModel> SaveCommand => new AsyncRelayCommand<DayRecordModel>(ToogleRossarySelectionAsync!);
        public IRelayCommand LoadCommand => new RelayCommand(LoadDays);

        private void LoadDays()
        {
            var startDate = DateTime.Now; //todo: move to add it by user in the first page
            for (int i = 0; i < NovennaDayLenght; i++)
            {
                var date = startDate.AddDays(i);
                Days.Add(new DayRecordModel(i, date));
            }
        }

        private async Task ToogleRossarySelectionAsync(DayRecordModel record)
        {
            await mediator.Send(new SaveRosarySelectionCommand(record.Id, 1, true));
        }
    }
}
