using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PompeiiNovenaCalendar.Domain.Models;
using PompeiiNovenaCalendar.Presentation.Resources.Localization;

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

        public IRelayCommand ToogleVisibilityCommand => new RelayCommand(ToogleVisibility!);

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
                SetProperty(ref _isCompleted, value);
                OnPropertyChanged(nameof(StatusName));

                if (!_isForceVisible)
                    IsVisible = !value;
            }
        }

        private bool _isForceVisible;
        private bool _isVisible;

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                SetProperty(ref _isVisible, value);
                OnPropertyChanged(nameof(VisibilityButtonText));
            }
        }

        public string VisibilityButtonText => IsVisible ? Strings.Collapse : Strings.Expand;

        private void ToogleVisibility()
        {
            IsVisible = !IsVisible;
            _isForceVisible = true;
        }
    }
}
