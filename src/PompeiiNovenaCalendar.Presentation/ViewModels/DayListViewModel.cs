﻿using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using FluentResults;
using PompeiiNovenaCalendar.Domain.Models;
using PompeiiNovenaCalendar.Presentation.Views;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Queries;

namespace PompeiiNovenaCalendar.Presentation.ViewModels
{
    public class DayListViewModel(IMediator mediator) : ObservableObject
    {
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

        public IRelayCommand<RosarySelectionModel> ToogleRossarySelectionCommand => new AsyncRelayCommand<RosarySelectionModel>(ToogleRossarySelectionAsync!);
        public IRelayCommand LoadCommand => new AsyncRelayCommand(LoadDaysAsync);
        public IRelayCommand GetDaysLengthToEndCommand => new AsyncRelayCommand(GetDaysLengthToEndAsync);
        public IRelayCommand ResetDaysCommand => new AsyncRelayCommand(ResetDaysAsync);

        private async Task LoadDaysAsync()
        {
            IEnumerable<DayRecordCollectionModel> days = await mediator.Send(new GetAllDayRecordsAsyncQuery());

            foreach (DayRecordCollectionModel day in days) 
            {
                Days.Add(day);
            }

            await GetDaysLengthToEndAsync();
        }

        private async Task GetDaysLengthToEndAsync()
        {
            DaysLengthToEnd = await mediator.Send(new GetDaysLengthToEndQuery());
        }

        private async Task ToogleRossarySelectionAsync(RosarySelectionModel record)
        {
            await mediator.Send(new ToogleRossarySelectionCommand(record.Id, record.DayId));
            await LoadDaysAsync();
        }

        private async Task ResetDaysAsync()
        {
            Result result = await mediator.Send(new ResetDaysCommand());

            if (result.IsFailed)
            {
                ErrorMessage = "An error occurred while resetting the calendar. Please try again.";
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(StartPage)}");
        }
    }
}
