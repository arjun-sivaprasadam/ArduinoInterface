namespace ArduinoInterface.UI.Core;

public class ViewModelBase : ObservableObject, IViewModelBase
{
    public string? Name { get; set; } = "Name not set!";

    public Type? Type { get; init; }

    public PackIconKind Kind { get; set; } = PackIconKind.None;

    public RelayCommand? SetView { get; set; }
}
public interface IViewModelBase
{
    public string? Name { get; set; }

    public Type? Type { get; init; }

    public PackIconKind Kind { get; set; }

    public RelayCommand? SetView { get; set; }
}
