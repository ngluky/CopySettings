using CopySettings.Hellp;
using Serilog;
using System.Windows;

namespace CopySettings
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Constants.Log = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.Async(a => a.File($"{System.AppDomain.CurrentDomain.BaseDirectory}\\logs\\log.txt", shared: true, rollingInterval: RollingInterval.Day))
                .CreateLogger();

            Constants.Log.Information("App start");

            base.OnStartup(e);
        }
    }




}
