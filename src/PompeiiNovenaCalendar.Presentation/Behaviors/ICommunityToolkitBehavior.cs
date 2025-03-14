﻿using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace PompeiiNovenaCalendar.Presentation.Behaviors;

public interface ICommunityToolkitBehavior<TView> where TView : Element
{
    /// <summary>
    /// View used by the Behavior
    /// </summary>
    protected TView? View { get; set; }

    [MemberNotNull(nameof(View))]
    internal void InitializeBehavior(TView bindable)
    {
        View = bindable;
        bindable.PropertyChanged += OnViewPropertyChanged;
    }

    internal void UninitializeBehavior(TView bindable)
    {
        bindable.PropertyChanged -= OnViewPropertyChanged;
        View = null;
    }

    /// <summary>
    /// Executes when <see cref="BindableObject.OnPropertyChanged"/> fires
    /// </summary>
    /// <param name="sender"><see cref="Behavior"/></param>
    /// <param name="e"><see cref="PropertyChangedEventArgs"/> </param>
    /// <exception cref="ArgumentException">Throws when <paramref name="sender"/> is not of type <typeparamref name="TView"/></exception>
    protected void OnViewPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (sender is not TView view)
        {
            throw new ArgumentException($"Behavior can only be attached to {typeof(TView)}");
        }

        try
        {
            OnViewPropertyChanged(view, e);
        }
        catch (Exception ex)
        {
            Trace.TraceInformation("{0}", ex);
        }
    }

    /// <summary>
    /// Virtual method that executes when a property on the View has changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnViewPropertyChanged(TView sender, PropertyChangedEventArgs e);
}