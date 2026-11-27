using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AIVideoCreator.WPF.Views;
using AIVideoCreator.WPF.Services;
using AIVideoCreator.WPF.ViewModels;

namespace AIVideoCreator.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainViewModel>();
                    services.AddHttpClient<IVideoService, VideoApiClient>(client =>
                    {
                        client.BaseAddress = new Uri(
                                context.Configuration["ApiSettings:BaseUrl"]!
                            );
                    });
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();

            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();

            _host.Dispose();

            base.OnExit(e);
        }
    }

}
