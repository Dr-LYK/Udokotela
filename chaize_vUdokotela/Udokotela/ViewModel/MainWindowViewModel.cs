using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Udokotela.Services;
using Udokotela.Utils;
using Udokotela.View;

namespace Udokotela.ViewModel
{
    public class MainWindowViewModel: BaseViewModel
    {
        public static ServiceUser.User User;
        
        #region Variables
        private bool _closeSignal;
        private CSUser _userService;
        private UserControl _content;
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
        /// <summary>
        /// Indique le contenu de la vue dynamique.
        /// </summary>
        public UserControl Content
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    OnPropertyChanged(nameof(Content));
                }
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur du ViewModel de la fenêtre principale.
        /// </summary>
        public MainWindowViewModel()
        {
            base.DisplayName = "Udokotela";
            this._userService = new CSUser();
            this._content = new HomeView(this);
            HomeCommand = new RelayCommand(param => ReturnHome(), param => true);
            UserProfileCommand = new RelayCommand(param => ShowUserProfile(), param => MainWindowViewModel.User != null);
            LogoutCommand = new RelayCommand(param => Logout(), param => MainWindowViewModel.User != null);
            UserManagementCommand = new RelayCommand(param => ShowUserManagementScreen(), param => true);
            PatientManagementCommand = new RelayCommand(param => ShowPatientManagementScreen(), param => true);
            LiveDataCommand = new RelayCommand(param => ShowLiveDataScreen(), param => true);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Fonction pour afficher la page d'accueil de l'application.
        /// </summary>
        private void ReturnHome()
        {
            this.Content = new HomeView(this);
        }

        /// <summary>
        /// Fonction pour afficher le profil utilisateur.
        /// </summary>
        private void ShowUserProfile()
        {
            this.Content = new UserSheetView(MainWindowViewModel.User);
        }

        /// <summary>
        /// Fonction pour déconnecter l'utilisateur.
        /// </summary>
        private void Logout()
        {
            this._userService.Disconnect(MainWindowViewModel.User.Login);
            WindowLoader.Show("Login");
            this.CloseSignal = true;
        }

        /// <summary>
        /// Fonction pour afficher la page de gestion des utilisateurs.
        /// </summary>
        private void ShowUserManagementScreen()
        {
            this.Content = new UserManagementView();
        }

        /// <summary>
        /// Fonction pour afficher la page de gestion des patients.
        /// </summary>
        private void ShowPatientManagementScreen()
        {
            this.Content = new PatientManagementView();
        }

        /// <summary>
        /// Fonction pour afficher la page de visualisation des données en temps réel.
        /// </summary>
        private void ShowLiveDataScreen()
        {
            this.Content = new LiveDataView();
        }

        /// <summary>
        /// Vérifie si l'utilisateur courant peut exécuter l'action en fonction de son rôle.
        /// </summary>
        public static bool CheckUserRole()
        {
            return (!(User.Role.Equals("Infirmière")));
        }
        #endregion
    }
}
