using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Udokotela.ServicePatient;
using Udokotela.Services;
using Udokotela.Utils;

namespace Udokotela.ViewModel
{
    public class PatientManagementViewModel: BaseViewModel
    {
        #region Variables
        private CSPatient _patientService;
        private ObservableCollection<Patient> _patients;
        #endregion

        #region Properties
        public ObservableCollection<Patient> Patients
        {
            get { return this._patients; }
            set
            {
                if (this._patients != value)
                {
                    this._patients = value;
                    this.OnPropertyChanged(nameof(Patient));
                }
            }
        }
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
            getPatientsInfo();
        }
        #endregion

        #region Methods
        private void getPatientsInfo()
        {

        }
        #endregion
    }
}
