using ArduinoInterface.Lib;

namespace ArduinoInterface.UI.ViewModel;

public class LedGridPageViewModel : ViewModelBase
{
    public LedGridPageViewModel()
    {
        Name = "";
        Kind = PackIconKind.LightbulbGroupOutline;
        Type = typeof(LedGridPageViewModel);
    }
}
