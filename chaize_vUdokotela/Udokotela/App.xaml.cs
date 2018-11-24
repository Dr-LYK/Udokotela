using System.Windows;
using Udokotela.Utils;

namespace Udokotela
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            WindowLoader.Show("Login");
        }
    }
}
