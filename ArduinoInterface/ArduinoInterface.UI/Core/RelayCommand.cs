namespace ArduinoInterface.UI.Core;

public class RelayCommand : ICommand
{
    private readonly Predicate<object>? _canExecute;
    private readonly Action<object> _execute;

    public RelayCommand(Action<object> execute, Predicate<object>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter) => _canExecute == null || _canExecute(parameter);

    public void Execute(object? parameter) => _execute(parameter);
}

public class RelayCommand<T> : ICommand
{
    private readonly Predicate<T>? _canExecute;
    private readonly Action<T> _execute;

    public RelayCommand(Action<T> execute, Predicate<T>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter) => _canExecute == null || _canExecute((T)parameter);

    public void Execute(object? parameter) => _execute((T)parameter);
}
