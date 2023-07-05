namespace ArduinoInterface.UI;
public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;
    public App()
    {
        ServiceCollection services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(ServiceCollection services)
    {
        // Register your services here
        services.AddSingleton<MainWindowView>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindowView mainWindowView = _serviceProvider.GetRequiredService<MainWindowView>();
        mainWindowView.Show();
    }
}
