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
        public static ServiceUser.User User;
        #region Variables
        private bool _closeSignal;
        private CSUser _userService;
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
            HomeCommand = new RelayCommand(param => ReturnHome(), param => true);
            UserProfileCommand = new RelayCommand(param => ShowUserProfile(), param => MainWindowViewModel.User != null);
            LogoutCommand = new RelayCommand(param => Logout(), param => MainWindowViewModel.User != null);
            UserManagementCommand = new RelayCommand(param => ShowUserManagementScreen(), param => true);
            PatientManagementCommand = new RelayCommand(param => ShowPatientManagementScreen(), param => true);
            LiveDataCommand = new RelayCommand(param => ShowLiveDataScreen(), param => true);
        }
        #endregion

        #region Methods
        private void ReturnHome()
        {
            ShowUserManagementScreen();
        }

        private void ShowUserProfile()
        {
            Console.WriteLine("Work In Progress: Showing profile of " + MainWindowViewModel.User.Firstname);
        }

        private void Logout()
        {
            this._userService.Disconnect(MainWindowViewModel.User.Login);
            WindowLoader.Show("Login");
            this.CloseSignal = true;
        }

        private void ShowUserManagementScreen()
        {
            Console.WriteLine("Work In Progress: Showing User Management screen");
        }

        private void ShowPatientManagementScreen()
        {
            Console.WriteLine("Work In Progress: Showing Patient Management screen");
        }

        private void ShowLiveDataScreen()
        {
            Console.WriteLine("Work In Progress: Showing Live Data screen");
        }
        #endregion
    }
}
