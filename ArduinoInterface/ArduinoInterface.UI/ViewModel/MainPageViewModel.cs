namespace ArduinoInterface.UI.ViewModel;

public class MainPageViewModel : ObservableObject
{
    private IViewModelBase? _currentView;

    public static string Version { get => "_1.0.0.0"; }

    public MainPageViewModel()
    {
    }

    public MainPageViewModel(IEnumerable<IViewModelBase> viewModels)
    {
        AppViews = new ObservableCollection<IViewModelBase>(viewModels);

        // Set the initial view
        CurrentView = AppViews.FirstOrDefault();
    }

    public ObservableCollection<IViewModelBase> AppViews { get; }

    public IViewModelBase? CurrentView
    {
        get => _currentView;
        set
        {
            if (value == null) return;
            SetProperty(ref _currentView, value);
        }
    }

    // Command to change the view
    public ICommand ChangeViewCommand => new RelayCommand<IViewModelBase>(ChangeView);

    private void ChangeView(IViewModelBase viewModel)
    {
        CurrentView = viewModel;
    }
}
