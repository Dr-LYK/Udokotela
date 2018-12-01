using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Udokotela.Services;
using Udokotela.ServiceUser;
using Udokotela.Utils;

namespace Udokotela.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        #region Variables
        private CSUser _userService;
        private ObservableCollection<User> _users;
        private MainWindowViewModel _mainView;
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
        public HomeViewModel(MainWindowViewModel mainView)
        {
            base.DisplayName = "Udokotela - Accueil";
            this._userService = new CSUser();
            this._mainView = mainView;
            GetUsersInfo();

            AddUserCommand = new RelayCommand(param => AddUser(), param => MainWindowViewModel.CheckUserRole());
            AddPatientCommand = new RelayCommand(param => AddPatient(), param => MainWindowViewModel.CheckUserRole());
            UserManagementCommand = new RelayCommand(param => UserManagement(), param => this._mainView.UserManagementCommand.CanExecute(param));
            PatientManagementCommand = new RelayCommand(param => PatientManagement(), param => this._mainView.PatientManagementCommand.CanExecute(param));
            LiveDataCommand = new RelayCommand(param => LiveData(), param => this._mainView.LiveDataCommand.CanExecute(param));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Action permettant à l'utilisateur d'ajouter un nouvel utilisateur.
        /// </summary>
        private void AddUser()
        {
            WindowLoader.Show("AddUser");
        }
        
        /// <summary>
        /// Action permettant à l'utilisateur d'ajouter un nouveau patient.
        /// </summary>
        private void AddPatient()
        {
            WindowLoader.Show("AddPatient");
        }

        /// <summary>
        /// Action permettant à l'utilisateur d'accéder à la gestion des utilisateurs.
        /// </summary>
        private void UserManagement()
        {
            this._mainView.UserManagementCommand.Execute(null);
        }

        /// <summary>
        /// Action permettant à l'utilisateur d'accéder à la gestion des patients.
        /// </summary>
        private void PatientManagement()
        {
            this._mainView.PatientManagementCommand.Execute(null);
        }

        /// <summary>
        /// Action permettant à l'utilisateur de visualiser les données en temps réel.
        /// </summary>
        private void LiveData()
        {
            this._mainView.LiveDataCommand.Execute(null);
        }

        private void GetUsersInfo()
        {
            List<User> users = _userService.GetUsers();
            this.Users = new ObservableCollection<User>(users);
        }
        #endregion
    }
}
