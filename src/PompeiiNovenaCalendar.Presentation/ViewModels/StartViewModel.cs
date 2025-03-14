using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using PompeiiNovenaCalendar.Presentation.Views;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Queries;

namespace PompeiiNovenaCalendar.Presentation.ViewModels
{
    public partial class StartViewModel(IMediator mediator) : ObservableObject
    {
        private DateTime _selectedDate = DateTime.Today;

        private DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }

        public IRelayCommand PageLoadedCommand => new AsyncRelayCommand(PageLoadedActionAsync);

        public IRelayCommand StartCommand => new AsyncRelayCommand(StartAsync);

        private async Task PageLoadedActionAsync()
        {
            bool isDataGenerated = await mediator.Send(new CheckIfCalendarWasGeneratedQuery());

            if (isDataGenerated)
            {
                await GoToCalendarAsync();
            }
        }

        private async Task StartAsync()
        {
            await mediator.Send(new GenerateInialDataCommand(SelectedDate));
            await GoToCalendarAsync();
        }

        private async Task GoToCalendarAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(DaysListPage)}?startDate={SelectedDate}");
        }
    }
}
