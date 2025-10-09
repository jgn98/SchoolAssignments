using System.Configuration;
using System.Data;
using System.Runtime.Serialization;
using System.Windows;
using WPFNavigation.Service;
using WPFNavigation.Stores;
using WPFNavigation.ViewModel;

namespace WPFNavigation;

public partial class App : Application
{
    
    private static NavigationStore nav = new NavigationStore();

    protected override void OnStartup(StartupEventArgs e)
    {
        
        MainWindow mainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(nav)
        };

        mainWindow.Show();

        base.OnStartup(e);
    }
}

