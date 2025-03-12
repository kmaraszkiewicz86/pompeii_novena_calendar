using System.Reflection;
using System.Windows.Input;

namespace PompeiiNovenaCalendar.Presentation.Behaviors
{
    public class EventToCommandBehavior : Behavior<View>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(EventToCommandBehavior));

        public static readonly BindableProperty EventNameProperty =
            BindableProperty.Create(nameof(EventName), typeof(string), typeof(EventToCommandBehavior));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public string EventName
        {
            get => (string)GetValue(EventNameProperty);
            set => SetValue(EventNameProperty, value);
        }

        private EventInfo _eventInfo;
        private Delegate _eventHandler;

        protected override void OnAttachedTo(View bindable)
        {
            base.OnAttachedTo(bindable);
            if (bindable == null || string.IsNullOrEmpty(EventName)) return;

            _eventInfo = bindable.GetType().GetEvent(EventName);
            if (_eventInfo == null) return;

            _eventHandler = Delegate.CreateDelegate(_eventInfo.EventHandlerType, this, nameof(OnEventRaised));
            _eventInfo.AddEventHandler(bindable, _eventHandler);
        }

        private void OnEventRaised(object sender, EventArgs e)
        {
            if (Command?.CanExecute(e) ?? false)
            {
                Command.Execute(e);
            }
        }

        protected override void OnDetachingFrom(View bindable)
        {
            base.OnDetachingFrom(bindable);
            if (_eventInfo != null && _eventHandler != null)
            {
                _eventInfo.RemoveEventHandler(bindable, _eventHandler);
            }
        }
    }

}
