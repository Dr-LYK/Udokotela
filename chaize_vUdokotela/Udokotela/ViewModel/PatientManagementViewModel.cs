using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Udokotela.ServicePatient;
using Udokotela.Services;
using Udokotela.Utils;
using Udokotela.View;

namespace Udokotela.ViewModel
{
    public class PatientManagementViewModel: BaseViewModel
    {
        #region Variables
        private CSPatient _patientService;
        private ObservableCollection<Patient> _patients;
        private Patient _patientSelected;
        private MainWindowViewModel _mainView;
        #endregion

        #region Properties
        public ObservableCollection<Patient> PatientList
        {
            get { return this._patients; }
            set
            {
                if (this._patients != value)
                {
                    this._patients = value;
                    this.OnPropertyChanged(nameof(PatientList));
                }
            }
        }

        public Patient PatientSelected
        {
            get { return this._patientSelected; }
            set
            {
                if (this._patientSelected != value)
                {
                    this._patientSelected = value;
                    this.OnPropertyChanged(nameof(PatientSelected));
                }
            }
        }

        public ICommand AddPatientCommand { get; set; }
        public ICommand DeleteSelectedPatientsCommand { get; set; }
        public ICommand OnRowDoubleClic { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur du ViewModel de connexion.
        /// </summary>
        public PatientManagementViewModel(MainWindowViewModel mainView)
        {
            base.DisplayName = "Udokotela - Gestion des patients";
            this._patientService = new CSPatient();
            this._mainView = mainView;
            GetPatientsInfo();

            this.AddPatientCommand = new RelayCommand(param => AddPatient(), param => MainWindowViewModel.CheckUserRole());
            this.DeleteSelectedPatientsCommand = new RelayCommand(param => DeleteSelectedPatient(), param => MainWindowViewModel.CheckUserRole() && this.PatientSelected != null);
            this.OnRowDoubleClic = new RelayCommand(param => ShowSelectedPatient(), param => this.PatientSelected != null);
        }
        #endregion

        #region Methods
        private void GetPatientsInfo()
        {
            List<Patient> patients = _patientService.GetPatients();
            this.PatientList = new ObservableCollection<Patient>(patients);
        }

        private void AddPatient()
        {
            WindowLoader.Show("AddPatient");
            // Problem: we have no clue when patient is created
            GetPatientsInfo();
        }

        private void DeleteSelectedPatient()
        {
            bool isUserDeleted = _patientService.DeleteUser(this.PatientSelected.Id);
            if (isUserDeleted)
            {
                this.PatientList.Remove(this.PatientSelected);
                this.PatientSelected = null;
            }
        }

        private void ShowSelectedPatient()
        {
            UserControl profileView = new PatientSheetView(this.PatientSelected, this._mainView);
            this._mainView.OverlayContent(profileView);
        }
        #endregion
    }
}
