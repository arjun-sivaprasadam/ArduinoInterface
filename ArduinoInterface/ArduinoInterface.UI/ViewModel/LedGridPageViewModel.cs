namespace ArduinoInterface.UI.ViewModel;

public class LedGridPageViewModel : ViewModelBase
{
    private RelayCommand? _writePattern;
    public RelayCommand? WritePattern
    {
        get => _writePattern;
        private set => SetProperty(ref _writePattern, value);
    }

    public LedGridPageViewModel()
    {
        Name = "";
        Kind = PackIconKind.LightbulbGroupOutline;
        Type = typeof(LedGridPageViewModel);

        WritePattern = new RelayCommand(WritePatternCommand);
    }

    private void WritePatternCommand(object parameter)
    {

    }
}