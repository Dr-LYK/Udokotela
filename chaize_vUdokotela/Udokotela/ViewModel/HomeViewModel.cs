using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Udokotela.Services;
using Udokotela.ServiceUser;

namespace Udokotela.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        #region Variables
        private CSUser _userService;
        private ObservableCollection<User> _users;
        #endregion

        #region Properties
        /// <summary>
        /// Liste de l'ensemble des utilisateurs.
        /// </summary>
        public ObservableCollection<User> Users
        {
            get { return this._users; }
            set
            {
                if (this._users != value)
                {
                    this._users = value;
                    this.OnPropertyChanged(nameof(Users));
                }
            }
        }

        /// <summary>
        /// Commande pour ajouter un utilisateur.
        /// </summary>
        public ICommand AddUserCommand { get; set; }

        /// <summary>
        /// Commande pour ouvrir le panneau de gestion des utilisateurs.
        /// </summary>
        public ICommand UserManagementCommand { get; set; }

        /// <summary>
        /// Commande pour ajouter un patient.
        /// </summary>
        public ICommand AddPatientCommand { get; set; }

        /// <summary>
        /// Commande pour ouvrir le panneau de gestion des patients.
        /// </summary>
        public ICommand PatientManagementCommand { get; set; }

        /// <summary>
        /// Commande pour accéder à lq visualisation des données en temps réel. 
        /// </summary>
        public ICommand LiveDataCommand { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur du ViewModel de la page d'accueil.
        /// </summary>
        public HomeViewModel()
        {
            base.DisplayName = "Udokotela - User Management";
            this._userService = new CSUser();
            getUsersInfo();
        }
        #endregion

        #region Methods
        private void getUsersInfo()
        {
            List<User> users = _userService.GetUsers();
            this.Users = new ObservableCollection<User>(users);
        }
        #endregion
    }
}
