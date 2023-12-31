﻿using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace QuadraticEquationSolver.ViewModels.Base;

internal partial class BaseViewModel : INotifyPropertyChanged
{
    protected static Logger _log = LogManager.GetCurrentClassLogger();
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
    {
        var handlers = PropertyChanged;
        if (handlers is null) return;

        var invokationList = handlers.GetInvocationList();
        var arg = new PropertyChangedEventArgs(PropertyName);
        foreach (var action in invokationList)
            if (action.Target is DispatcherObject dispatcherObject)
                dispatcherObject.Dispatcher.Invoke(action, this, arg);
            else
                action.DynamicInvoke(this, arg);
    }

    protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
    {
        if (Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(PropertyName);
        return true;
    }

    protected virtual bool Set<T>(ref T field, T value, Func<T, bool> validator, [CallerMemberName] string PropertyName = null)
    {
        if (Equals(field, value) || !validator(value))
            return false;

        field = value;
        OnPropertyChanged(PropertyName);
        return true;
    }

    protected virtual bool Set<T>(
        ref T field,
        T value,
        string validationErrorMessage,
        Func<T, bool> validator,
        [CallerMemberName] string PropertyName = null)
    {
        if (Equals(field, value))
            return false;
        if(!validator(value))
            throw new ArgumentException(validationErrorMessage ?? $"Ошибка валидации данных св-ва {PropertyName}", PropertyName);

        field = value;
        OnPropertyChanged(PropertyName);
        return true;
    }

    protected virtual bool Set<T>(T value, T oldValue, Action<T> setter, [CallerMemberName] string PropertyName = null)
    {
        if (Equals(oldValue, value)) return false;

        setter(value);
        OnPropertyChanged();
        return true;
    }


    private readonly Dictionary<string, object> _propertyValues = new ();

    protected T? Get<T>([CallerMemberName] string PropertyName = null!) =>
        _propertyValues.TryGetValue(PropertyName, out var value) ? (T?)value! : default;

    protected bool Set<T>(T value, [CallerMemberName] string PropertyName = null)
    {
        if(_propertyValues.TryGetValue(PropertyName, out var oldValue) && Equals(oldValue, value))
            return false;
            
        _propertyValues[PropertyName] = value;
        OnPropertyChanged(PropertyName);
        return true;
    }
       
}