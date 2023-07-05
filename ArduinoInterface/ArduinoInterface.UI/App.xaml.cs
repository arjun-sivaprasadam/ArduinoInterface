using Microsoft.Extensions.DependencyInjection;

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
        services.AddSingleton<MainPageView>(provider => new MainPageView()
        {
            DataContext = provider.GetService<MainPageViewModel>()
        });
        services.AddSingleton<LedGridPageView>(provider => new LedGridPageView()
        {
            DataContext = provider.GetService<LedGridPageViewModel>()
        });
        services.AddSingleton<SettingsPageView>(provider => new SettingsPageView()
        {
            DataContext = provider.GetService<SettingsPageViewModel>()
        });

        // Register your services here
        services.AddSingleton<MainPageView>();
        services.AddSingleton<LedGridPageView>();
        services.AddSingleton<SettingsPageView>();

        services.AddSingleton<MainPageViewModel>();
        services.AddSingleton<IViewModelBase, LedGridPageViewModel>();
        services.AddSingleton<IViewModelBase, SettingsPageViewModel>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        MainPageView mainWindowView = _serviceProvider.GetRequiredService<MainPageView>();
        mainWindowView.DataContext = _serviceProvider.GetRequiredService<MainPageViewModel>();
        mainWindowView.Show();
    }
}