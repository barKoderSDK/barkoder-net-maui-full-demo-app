using Android.App;
using Android.Runtime;
using BarkoderMaui.Utils;

namespace BarkoderMaui;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
        AndroidEnvironment.UnhandledExceptionRaiser += (_, e) =>
        {
            AppLogger.Error("AndroidEnvironment.UnhandledException", e.Exception);
            e.Handled = false;
        };
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

