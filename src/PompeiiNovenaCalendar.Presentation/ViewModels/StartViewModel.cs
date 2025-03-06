using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PompeiiNovenaCalendar.Presentation.Views;

namespace PompeiiNovenaCalendar.Presentation.ViewModels
{
    public partial class StartViewModel : ObservableObject
    {
        private DateTime _selectedDate = DateTime.Today;

        private DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }

        public ICommand StartCommand => new RelayCommand(Start);

        private async void Start()
        {
            await Shell.Current.GoToAsync($"{nameof(DaysListPage)}?startDate={SelectedDate}");
        }
    }
}
