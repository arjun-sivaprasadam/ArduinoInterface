namespace ArduinoInterface.UI.View;

public partial class LedGridPageView : UserControl
{
    public LedGridPageView()
    {
        InitializeComponent();
    }

    public LedGridPageView(LedGridPageViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}