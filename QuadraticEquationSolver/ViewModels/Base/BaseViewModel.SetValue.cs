using System;
using System.Runtime.CompilerServices;

namespace QuadraticEquationSolver.ViewModels.Base;

partial class BaseViewModel
{
    public readonly ref struct SetValueResult<T>
    {
        private readonly bool _result;
        private readonly T _oldValue;
        private readonly T _newValue;
        private readonly BaseViewModel _vm;

        public SetValueResult(bool result, in T oldValue, in T newValue, BaseViewModel vm)
        {
            _result = result;
            _oldValue = oldValue;
            _newValue = newValue;
            _vm = vm;
        }

        public SetValueResult<T> Then(Action<T> action)
        {
            if (_result)
                action(_newValue);

            return this;
        }

        public SetValueResult<T> ThenIf(Func<T, bool> valueChecker, Action<T> action)
        {
            if (_result && valueChecker(_newValue))
                action(_newValue);

            return this;
        }

        public SetValueResult<T> UpdateProperty(string propertyName)
        {
            if (_result)
                _vm.OnPropertyChanged(propertyName);
            return this;
        }

    }

    //protected SetValueResult<T> SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    //{
    //    if(Equals(field, value)) 
    //        return new(false, field, value, this);
    
    //    field = value;
    //    OnPropertyChanged(propertyName);
    //    return new(true, field, value, this);
    //}
}

