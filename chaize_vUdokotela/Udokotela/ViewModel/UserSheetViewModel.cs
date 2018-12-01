using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Udokotela.ServicePatient;
using Udokotela.Services;
using Udokotela.ServiceUser;
using Udokotela.Utils;

namespace Udokotela.ViewModel
{
    public class UserSheetViewModel : BaseViewModel
    {
        #region Attributes
        private User _userToDisplay;
        private MainWindowViewModel _mainView;
        #endregion

        #region Properties

        /// <summary>
        /// Nom de famille de l'utilisateur.
        /// </summary>
        public string Name
        {
            get { return _userToDisplay.Name; }
        }

        /// <summary>
        /// Prénom de l'utilisateur.
        /// </summary>
        public string FirstName
        {
            get { return _userToDisplay.Firstname; }
        }

        /// <summary>
        /// Login de l'utilisateur.
        /// </summary>
        public string Login
        {
            get { return _userToDisplay.Login; }
        }

        /// <summary>
        /// Role de l'utilisateur.
        /// </summary>
        public string Role
        {
            get { return _userToDisplay.Role; }
        }

        /// <summary>
        /// Image de l'utilisateur.
        /// </summary>
        public byte[] Picture
        {
            get { return _userToDisplay.Picture; }
        }

        /// <summary>
        /// Status de connexion de l'utilisateur.
        /// </summary>
        public string Status
        {
            get { return _userToDisplay.Connected ? "Connecté" : "Déconnecté";  }
        }

        public ICommand BackCommand { get; set; }

        #endregion

        #region Constructors
        public UserSheetViewModel(User userToDisplay, MainWindowViewModel mainView = null)
        {
            this._userToDisplay = userToDisplay;
            this._mainView = mainView;
            base.DisplayName = $"Udokotela - {FirstName} {Name}";
            this.BackCommand = new RelayCommand(param => DismissBack(), param => this._mainView != null && this._mainView.HasBackgroundContent());
        }
        #endregion

        #region Methods
        private void DismissBack()
        {
            this._mainView.ContentBack();
        }
        #endregion
    }
}
