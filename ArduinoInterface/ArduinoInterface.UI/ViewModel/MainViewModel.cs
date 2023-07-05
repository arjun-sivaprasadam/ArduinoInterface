using System.Collections.ObjectModel;

namespace ArduinoInterface.UI.ViewModel;
public class MainViewModel : ObservableObject
{
    private static readonly MainViewModel _instance = new MainViewModel();
    public static MainViewModel Instance => _instance;

    private IViewModelBase? _currentView;
    public IViewModelBase Blank, Home, Login, LogTemplate, Graph, Logs, Settings;
    private short _selectedIndex;

    public static string Version { get => "_1.0.0.0"; }

    public MainViewModel()
    {
        Blank = new BlankPageViewModel();
        AppViews = new ObservableCollection<IViewModelBase>
        {
            Blank,
            //Home,
            //Login,
            //LogTemplate,
            //Logs,
            //Settings,
        };

        for (short i = 0; i < AppViews.Count; i++)
        {
            // Don't remove this var temp, because at the execution time of this Lambda function the i always is at the value of AppViews.Count
            // But if temp is used this will create a point of reference to the temp variables which is created for every loop iteration.
            // Hence during the evaluation the Lambda function reads the correct temp value, ie: @ i==1, temp ==1, but evaluated i = AppViews.Count
            // and @ i==2, temp ==2, 'similarly, i = AppViews.Count again during evaluation.
            var temp = i;
            AppViews[temp].SetView = new RelayCommand(o =>
            {
                CurrentView = AppViews[temp];
                SelectedIndex = temp;
            });
        }

        //CurrentView = AppViews[_selectedIndex];
        SelectedIndex = GetViewModelIndexByType(typeof(BlankPageViewModel));
        ToggleLightCommand = new RelayCommand(ToggleLight);
    }

    public ObservableCollection<IViewModelBase> AppViews { get; }

    public short GetViewModelIndexByType(Type type)
    {
        for (short i = 0; i < AppViews.Count; i++)
        {
            var view = AppViews[i];
            if (view.GetType() == type)
                return i;
        }

        throw new Exception("This Type is invalid for a view model base!");
    }

    public short SelectedIndex
    {
        get => _selectedIndex;
        set => SetProperty(ref _selectedIndex, value);
    }

    public IViewModelBase? CurrentView
    {
        get => _currentView;
        set
        {
            if (value == null) return;
            _ = SetProperty(ref _currentView, value);
            SelectedIndex =
                (short)AppViews.IndexOf(_currentView ?? throw new NullReferenceException(nameof(_currentView)));
        }
    }

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
}
