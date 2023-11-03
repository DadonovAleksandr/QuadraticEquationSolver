using System.Runtime.CompilerServices;

namespace QuadraticEquationSolver.ViewModels.Base;

internal partial class BaseViewModel
{
    private SetValueResult<T> SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if(Equals(field, value)) 
            return new SetValueResult<T>(false, field, value, this);
    
        field = value;
        OnPropertyChanged(propertyName);
        return new SetValueResult<T>(true, field, value, this);
    }
}

internal class SetValueResult<T>
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
}