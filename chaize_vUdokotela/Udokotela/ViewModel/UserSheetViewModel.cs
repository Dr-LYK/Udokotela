using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Udokotela.ServicePatient;
using Udokotela.Services;
using Udokotela.Utils;

namespace Udokotela.ViewModel
{
    public class UserSheetViewModel : BaseViewModel
    {
        #region Attributes
        private bool _closeSignal;
        #endregion

        #region Properties
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
        /// Nom de famille de l'utilisateur.
        /// </summary>
        public string Name
        {
            get { return MainWindowViewModel.User.Name; }
        }

        /// <summary>
        /// Prénom de l'utilisateur à créer.
        /// </summary>
        public string FirstName
        {
            get { return MainWindowViewModel.User.Firstname; }
        }

        /// <summary>
        /// Role de l'utilisateur.
        /// </summary>
        public string Role
        {
            get { return MainWindowViewModel.User.Role; }
        }

        /// <summary>
        /// Commande pour creer et enregistrer l'utilisateur.
        /// </summary>
        public ICommand CloseWindowCommand { get; set; }

        #endregion

        #region Constructors
        public UserSheetViewModel()
        {
            base.DisplayName = $"{FirstName} {Name}";

            CloseWindowCommand = new RelayCommand(param => CloseWindow(), param => true);
        }
        #endregion

        #region Methods

        /// <summary>
        /// Action permettant de fermer la fenetre du profile.
        /// </summary>
        private void CloseWindow()
        {
            this.CloseSignal = true;
        }
        #endregion
    }
}
