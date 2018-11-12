using System.Windows;

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

            View.LoginView loginView = new View.LoginView();
            ViewModel.LoginViewModel loginViewModel = new ViewModel.LoginViewModel();

            loginView.DataContext = loginViewModel;
            loginView.Show();
        }
    }
}
