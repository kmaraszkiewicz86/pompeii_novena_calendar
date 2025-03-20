using CommunityToolkit.Mvvm.ComponentModel;
using PompeiiNovenaCalendar.Domain.Models;

namespace PompeiiNovenaCalendar.Presentation.ViewModels
{
    public class DayRecordViewModel : ObservableObject
    {
        private readonly DayRecordCollectionModel _model;

        public DayRecordViewModel(DayRecordCollectionModel model)
        {
            _model = model;
            IsCompleted = _model.IsCompleted;
        }

        public int Id => _model.Id;
        public DateTime Day => _model.Day;
        public string StatusName => IsCompleted ? "✔️" : "❌";
        public HashSet<RosarySelectionModel> RosarySelections => _model.RosarySelections;

        private bool _isCompleted;
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                if (_isCompleted != value)
                {
                    SetProperty(ref _isCompleted, value);
                    OnPropertyChanged(nameof(StatusName));
                }
            }
        }
    }
}
