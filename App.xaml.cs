using BarkoderMaui.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace BarkoderMaui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        HookGlobalExceptionLogging();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell());
	}

    private static void HookGlobalExceptionLogging()
    {
        AppDomain.CurrentDomain.UnhandledException += (_, e) =>
        {
            var ex = e.ExceptionObject as Exception;
            if (ex == null)
            {
                AppLogger.Error($"UnhandledException (non-Exception): {e.ExceptionObject}");
                return;
            }
            AppLogger.Error("UnhandledException", ex);
        };

        TaskScheduler.UnobservedTaskException += (_, e) =>
        {
            AppLogger.Error("UnobservedTaskException", e.Exception);
            e.SetObserved();
        };
    }
}
