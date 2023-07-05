namespace ArduinoInterface.UI.View;

public partial class MainWindowView : Window
{
    public MainWindowView()
    {
        InitializeComponent();
        DataContext ??= new MainViewModel();
    }
}
