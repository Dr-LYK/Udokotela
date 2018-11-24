using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Udokotela.Utils;

namespace Udokotela.ViewModel
{
    public class MainWindowViewModel: BaseViewModel
    {
        #region Variables
        private bool _closeSignal;
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
            UserProfileCommand = new RelayCommand(param => ShowUserProfile(), param => this.User != null);
            LogoutCommand = new RelayCommand(param => Logout(), param => true);
        }
        #endregion

        private void Logout()
        {
            this.CloseSignal = true;
            WindowLoader.Show("Login");
        }

        private void ShowUserProfile()
        {
            Console.WriteLine("Work In Progress: Showing profile of " + User.Firstname);
        }
    }
}
