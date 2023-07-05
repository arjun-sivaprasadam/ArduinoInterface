namespace ArduinoInterface.UI.ViewModel;

public class SettingsPageViewModel : ViewModelBase
{
    private bool _isLightOn;
    public bool IsLightOn
    {
        get => _isLightOn;
        set => SetProperty(ref _isLightOn, value);
    }

    private string _offTime;
    public string OffTime
    {
        get => _offTime;
        set => SetProperty(ref _offTime, value);
    }

    private string _onTime;
    public string OnTime
    {
        get => _onTime;
        set => SetProperty(ref _onTime, value);
    }

    private RelayCommand _toggleLightCommand;
    public RelayCommand ToggleLightCommand
    {
        get => _toggleLightCommand;
        set => SetProperty(ref _toggleLightCommand, value);
    }

    private void ToggleLight(object obj)
    {
        IsLightOn = !IsLightOn;

        //Program.Init();
        //Program.ToggleLight(IsLightOn);
    }

    public SettingsPageViewModel()
    {
        Name = "";
        Kind = PackIconKind.Cog;
        Type = typeof(SettingsPageViewModel);
    }
}
