using MaterialDesignThemes.Wpf;

using System.Diagnostics;

namespace ArduinoInterface.UI.View;

public partial class MainPageView : Window
{
    public MainPageView()
    {
        InitializeComponent();
        //DataContext ??= new MainPageViewModel();
    }

    public MainPageView(MainPageViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void WindowDrag_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left) DragMove();
    }

    private void Window_Close(object sender, RoutedEventArgs e) => Close();

    private void Window_Maximize(object sender, RoutedEventArgs e)
    {
        Debug.Assert(Application.Current.MainWindow != null, "Application.Current.MainWindow != null");

        var btn = sender as Button ?? throw new NullReferenceException(nameof(sender));
        var icon = btn.Content as PackIcon ?? throw new NullReferenceException(nameof(btn));

        if (Application.Current.MainWindow.WindowState == WindowState.Normal)
        {
            WindowState = WindowState.Maximized;
            icon.Kind = PackIconKind.WindowRestore;
        }
        else if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
        {
            WindowState = WindowState.Normal;
            icon.Kind = PackIconKind.WindowMaximize;
        }
    }

    private void Window_Minimize(object sender, RoutedEventArgs e) =>
        WindowState = WindowState.Minimized;

    private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (e.OriginalSource is CheckBox || e.OriginalSource is TextBlock || e.OriginalSource is System.Windows.Shapes.Path)
        {
            // do nothing
            return;
        }
        Debug.Assert(Application.Current.MainWindow != null, "Application.Current.MainWindow != null");
        if (Application.Current.MainWindow.WindowState == WindowState.Normal)
            WindowState = WindowState.Maximized;
        else if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
            WindowState = WindowState.Normal;
    }
}
