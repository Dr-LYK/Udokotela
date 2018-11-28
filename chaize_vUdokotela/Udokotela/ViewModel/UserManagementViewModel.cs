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
        private ObservableCollection<User> _users;
        #endregion

        #region Properties
        /// <summary>
        /// List of all users.
        /// </summary>
        public ObservableCollection<User> Users
        {
            get { return this._users;  }
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
        /// Commande pour ouvrir le panneau de gestion des users.
        /// </summary>
        public ICommand UserManagementCommand { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur du ViewModel de connexion.
        /// </summary>
        public UserManagementViewModel()
        {
            base.DisplayName = "Udokotela - Gestion des utilisateurs";
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
