using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Udokotela.Services;
using Udokotela.Utils;

namespace Udokotela.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Variables
        private CSUser _userService;
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

            _userService = new CSUser();
            LoginCommand = new RelayCommand(param => LoginAccess(), param => CanLogin());
        }
        #endregion

        /// <summary>
        /// Action permettant à l'utilisateur de se connecter.
        /// </summary>
        private void LoginAccess()
        {
            if (_userService.Login(_login, _password))
            {
                ServiceUser.User loggedUser = _userService.GetUser(_login);
                if (loggedUser != null)
                {
                    Console.WriteLine("Welcome back " + loggedUser.Firstname + "!");
                    WindowLoader.Show("MainWindow");
                    CloseSignal = true;
                    return;
                }
                else
                {
                    Console.WriteLine("Failed to get logged user");
                }
            }
            else
            {
                Console.WriteLine("Invalid credentials");
            }
        }

        private bool CanLogin()
        {
            return !(this._login == null || this._login == "" || this._password == null || this._password == "");
        }
    }
}
