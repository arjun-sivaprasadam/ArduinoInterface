namespace ArduinoInterface.UI.ViewModel;

public class BlankPageViewModel : ViewModelBase
{
    public BlankPageViewModel()
    {
        Name = "_";
        Kind = PackIconKind.CheckboxBlankBadgeOutline;
        Type = typeof(BlankPageViewModel);
    }
}