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
    public class UserManagementViewModel: BaseViewModel
    {
        #region Variables
        private CSUser _userService;
        #endregion

        #region Properties
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
            base.DisplayName = "Udokotela - User Management";
            this._userService = new CSUser();
        }
        #endregion

        #region Methods
        #endregion
    }
}
