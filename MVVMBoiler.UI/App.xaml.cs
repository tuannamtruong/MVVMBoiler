using System.Windows;
using Autofac;

namespace MVVMBoiler.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Startup startup = new Startup();
            var container = startup.Configure();
            MainWindow window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}
