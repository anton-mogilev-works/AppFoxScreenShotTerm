using AppFoxScreenShotTerm.ViewModels;
using AppFoxScreenShotTerm.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System.IO;
using AppFoxScreenShotTerm.Helpers;
using System;

namespace AppFoxScreenShotTerm
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            string screenshotsDir = Params.applicationPath + Path.DirectorySeparatorChar + Params.SCREENS_FOLDER;
            string downloadDir = Params.applicationPath + Path.DirectorySeparatorChar + Params.DOWNLOAD_FOLDER;

            if (Directory.Exists(screenshotsDir) == false)
            {
                Directory.CreateDirectory(screenshotsDir);
            }

            if (Directory.Exists(downloadDir) == false)
            {
                Directory.CreateDirectory(downloadDir);
            }           


            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {                    
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
