using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PompeiiNovenaCalendar.Domain.Models;

namespace PompeiiNovenaCalendar.Presentation.ViewModels
{
    public class DayListViewModel : ObservableObject
    {
        private const int NovennaDayLenght = 54;

        private ObservableCollection<DayRecordModel> _days = new();

        public ObservableCollection<DayRecordModel> Days
        {
            get => _days;
            set => SetProperty(ref _days, value);
        }

        public DayListViewModel()
        {
            LoadDays();//todo: move to add it to load page event
        }

        private void LoadDays()
        {
            var startDate = DateTime.Now; //todo: move to add it by user in the first page
            for (int i = 0; i < NovennaDayLenght; i++)
            {
                var date = startDate.AddDays(i);
                Days.Add(new DayRecordModel(i, date));
            }
        }
    }
}
