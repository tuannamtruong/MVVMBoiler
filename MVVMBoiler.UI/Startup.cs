using Autofac;
using MVVMBoiler.UI.Services.Data;

namespace MVVMBoiler.UI
{
    class Startup
    {
        public IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainWindowViewModel>().AsSelf();
            builder.RegisterType<CustomersRepository>().As<ICustomersRepository>();
            return builder.Build();
        }
    }
}
