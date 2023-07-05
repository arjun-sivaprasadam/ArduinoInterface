using System.Windows.Controls.Primitives;

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

    private void ToggleButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is ToggleButton toggleButton)
        {
            int column = Grid.GetColumn(toggleButton);
            int row = Grid.GetRow(toggleButton);
            Console.WriteLine($"Clicked button at column {column}, row {row}");

            // Toggle the icon
            toggleButton.Background = new SolidColorBrush(Colors.Red) { Opacity = 0.25 };
            PackIcon packIcon = (PackIcon)toggleButton.Content;
            packIcon.Kind = packIcon.Kind == PackIconKind.LedOn ? PackIconKind.LedOff : PackIconKind.LedOn;

            if (DataContext is not null)
                (DataContext as LedGridPageViewModel)?.WritePattern?.Execute(new WritePatternParameters(row, column, packIcon.Kind == PackIconKind.LedOn));
        }
    }
}
