using ArduinoInterface.Lib;

namespace ArduinoInterface.UI.ViewModel;

public class LedGridPageViewModel : ViewModelBase
{
    private RelayCommand<WritePatternParameters>? _writePattern;
    public RelayCommand<WritePatternParameters>? WritePattern
    {
        get => _writePattern;
        private set => SetProperty(ref _writePattern, value);
    }

    public LedGridPageViewModel()
    {
        Name = "";
        Kind = PackIconKind.LightbulbGroupOutline;
        Type = typeof(LedGridPageViewModel);

        WritePattern = new RelayCommand<WritePatternParameters>(WritePatternCommand);
    }

    private void WritePatternCommand(WritePatternParameters parameter)
    {
        Console.WriteLine("");
    }
}

public class WritePatternParameters
{
    public int Row { get; set; }
    public int Col { get; set; }

    public bool IsToggled { get; set; }

    public WritePatternParameters(int row, int col, bool isToggled)
    {
        Row = row;
        Col = col;
        IsToggled = isToggled;

        ArduinoController.SendLedUpdates(row, col, isToggled);
    }
}
