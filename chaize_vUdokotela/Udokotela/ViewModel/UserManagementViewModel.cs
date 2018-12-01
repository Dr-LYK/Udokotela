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
    public class UserManagementViewModel: BaseViewModel
    {
        #region Variables
        private CSUser _userService;
        private ObservableCollection<User> _userList;
        #endregion

        #region Properties
        /// <summary>
        /// List of all users.
        /// </summary>
        public ObservableCollection<User> UserList
        {
            get { return this._userList;  }
            set
            {
                if (this._userList != value)
                {
                    this._userList = value;
                    this.OnPropertyChanged(nameof(UserList));
                }
            }
        }

        public ICommand AddUserCommand { get; set; }
        public ICommand DeleteSelectedUsersCommand { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur du ViewModel de connexion.
        /// </summary>
        public UserManagementViewModel()
        {
            base.DisplayName = "Udokotela - Gestion des utilisateurs";
            _userService = new CSUser();
            GetUsersInfo();

            AddUserCommand = new RelayCommand(param => AddUser(), param => MainWindowViewModel.CheckUserRole());
            DeleteSelectedUsersCommand = new RelayCommand(param => DeleteSelectedUsers(), param => true);
        }
        #endregion

        #region Methods
        private void GetUsersInfo()
        {
            List<User> users = _userService.GetUsers();
            this.UserList = new ObservableCollection<User>(users);
        }

        private void AddUser()
        {
            /* TODO */
        }

        private void DeleteSelectedUsers()
        {
            /* TODO */
        }
        #endregion
    }
}
