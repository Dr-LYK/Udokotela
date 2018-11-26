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
    public class PatientManagementViewModel: BaseViewModel
    {
        #region Variables
        private CSPatient _patientService;
        #endregion

        #region Properties
        /// <summary>
        /// Commande pour ouvrir le panneau de gestion des patients.
        /// </summary>
        public ICommand PatientManagementCommand { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur du ViewModel de connexion.
        /// </summary>
        public PatientManagementViewModel()
        {
            base.DisplayName = "Udokotela - Patient Management";
            this._patientService = new CSPatient();
        }
        #endregion

        #region Methods
        #endregion
    }
}
