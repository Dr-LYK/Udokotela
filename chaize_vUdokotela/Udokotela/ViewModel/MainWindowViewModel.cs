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
    public class MainWindowViewModel: BaseViewModel
    {
        #region Variables
        private bool _closeSignal;
        private CSUser _userService;
        public ServiceUser.User User;
        #endregion

        #region Properties
        /// <summary>
        /// Commande pour accéder à la page d'accueil.
        /// </summary>
        public ICommand HomeCommand { get; set; }

        /// <summary>
        /// Commande pour accéder au profil de l'utilisateur.
        /// </summary>
        public ICommand UserProfileCommand { get; set; }

        /// <summary>
        /// Commande pour se déconnecter de l'application.
        /// </summary>
        public ICommand LogoutCommand { get; set; }

        /// <summary>
        /// Commande pour ouvrir le panneau de gestion des utilisateurs.
        /// </summary>
        public ICommand UserManagementCommand { get; set; }

        /// <summary>
        /// Commande pour ouvrir le panneau de gestion des patients.
        /// </summary>
        public ICommand PatientManagementCommand { get; set; }

        /// <summary>
        /// Commande pour ouvrir l'affichage des données en temps réel.
        /// </summary>
        public ICommand LiveDataCommand { get; set; }
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
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur du ViewModel de connexion.
        /// </summary>
        public MainWindowViewModel()
        {
            base.DisplayName = "Udokotela";
            this._userService = new CSUser();
            UserProfileCommand = new RelayCommand(param => ShowUserProfile(), param => this.User != null);
            LogoutCommand = new RelayCommand(param => Logout(), param => this.User != null);
        }
        #endregion

        #region Methods
        private void Logout()
        {
            this._userService.Disconnect(this.User.Login);
            this.CloseSignal = true;
            WindowLoader.Show("Login");
        }

        private void ShowUserProfile()
        {
            Console.WriteLine("Work In Progress: Showing profile of " + this.User.Firstname);
        }
        #endregion
    }
}
