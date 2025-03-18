using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentResults;
using MediatR;
using PompeiiNovenaCalendar.Presentation.Views;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Queries;

namespace PompeiiNovenaCalendar.Presentation.ViewModels
{
    public partial class StartViewModel(IMediator mediator) : ObservableObject
    {
        private DateTime _selectedDate = DateTime.Today;

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }

        private string _errorMessage = string.Empty;

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                SetProperty(ref _errorMessage, value);
                OnPropertyChanged(nameof(IsValid));
            }
        }

        private bool IsValid => string.IsNullOrEmpty(ErrorMessage);

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
            Result result = await mediator.Send(new GenerateInialDataCommand(SelectedDate));

            if (result.IsFailed)
            {
                ErrorMessage = "An error occurred while generating the calendar. Please try again.";
                return;
            }

            await GoToCalendarAsync();
        }

        private static async Task GoToCalendarAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(DaysListPage)}");
        }
    }
}
