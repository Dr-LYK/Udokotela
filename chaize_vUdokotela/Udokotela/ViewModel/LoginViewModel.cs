using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Udokotela.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Variables
        private ServiceUser.ServiceUserClient _client;
        private bool _closeSignal;
        private string _login;
        private string _password;
        #endregion


        #region Properties
        /// <summary>
        /// Commande pour s'authentifier.
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// Indique si la fenêtre doit être fermée ou non.
        /// </summary>
        public bool CloseSignal
        {
            get { return _closeSignal; }
            set
            {
                if (_closeSignal != value)
                {
                    _closeSignal = value;
                    OnPropertyChanged(nameof(CloseSignal));
                }
            }
        }

        /// <summary>
        /// Identifiant de l'utilisateur.
        /// </summary>
        public string Login
        {
            get { return _login; }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged(nameof(Login));
                }
            }
        }

        /// <summary>
        /// Mot de passe de l'utilisateur.
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur du ViewModel de connexion.
        /// </summary>
        public LoginViewModel()
        {
            base.DisplayName = "Page de connexion";
            Login = "";
            Password = "";

            _client = new ServiceUser.ServiceUserClient();
            LoginCommand = new RelayCommand(param => LoginAccess(), param => true);
        }
        #endregion

        /// <summary>
        /// Action permettant à l'utilisateur de se connecter.
        /// </summary>
        private async void LoginAccess()
        {
            if (await _client.ConnectAsync(_login, _password))
            {
                Console.WriteLine("Bien ouej !");
            }
            else
            {
                Console.WriteLine("You fucked bro'");
            }
        }
    }
}
