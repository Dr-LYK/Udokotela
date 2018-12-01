using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Udokotela.ServicePatient;
using Udokotela.Services;
using Udokotela.View;

namespace Udokotela.ViewModel
{
    /// <summary>
    /// Classe de ViewModel pour la fiche patient.
    /// </summary>
    public class PatientSheetViewModel : BaseViewModel
    {
        #region Attributes
        private Patient _patientToDisplay;
        private MainWindowViewModel _mainView;
        private ObservableCollection<Observation> _observations;
        #endregion

        #region Properties
        /// <summary>
        /// Numéro identifiant du patient.
        /// </summary>
        public int Id
        {
            get { return _patientToDisplay.Id; }
        }

        /// <summary>
        /// Nom de famille du patient.
        /// </summary>
        public string Name
        {
            get { return _patientToDisplay.Name; }
        }

        /// <summary>
        /// Prénom du patient.
        /// </summary>
        public string FirstName
        {
            get { return _patientToDisplay.Firstname; }
        }

        /// <summary>
        /// Date de naissance du patient.
        /// </summary>
        public string Birthdate
        {
            get { return _patientToDisplay.Birthday.ToString("d", CultureInfo.CreateSpecificCulture("fr-FR")); }
        }

        /// <summary>
        /// Observations on current patient
        /// </summary>
        public ObservableCollection<Observation> ObservationList
        {
            get { return this._observations; }
            set
            {
                if (this._observations != value)
                {
                    this._observations = value;
                    OnPropertyChanged(nameof(ObservationList));
                }
            }
        }

        public ICommand BackCommand { get; set; }
        public ICommand OnRowDoubleClic { get; set; }

        #endregion

        //                  SelectedItem="{Binding ObservationSelected, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"


        #region Constructors
        public PatientSheetViewModel(Patient patientToDisplay, MainWindowViewModel mainView = null)
        {
            this._patientToDisplay = patientToDisplay;
            this._mainView = mainView;
            base.DisplayName = $"Udokotela - {FirstName} {Name}";
            this.BackCommand = new RelayCommand(param => DismissBack(), param => this._mainView != null && this._mainView.HasBackgroundContent());
            this.OnRowDoubleClic = new RelayCommand(param => ShowObservation(param as Observation), param => true);
        }
        #endregion

        #region Methods
        private void DismissBack()
        {
            this._mainView.ContentBack();
        }

        private void ShowObservation(Observation observation)
        {
            ServiceObservation.Observation serviceObservation = new ServiceObservation.Observation() {
                BloodPressure = observation.BloodPressure,
                Comment = observation.Comment,
                Date = observation.Date,
                ExtensionData = observation.ExtensionData,
                Pictures = observation.Pictures,
                Prescription = observation.Prescription,
                Weight = observation.Weight
            };
            UserControl observationView = new ObservationSheetView(this._patientToDisplay, serviceObservation, this._mainView);
            this._mainView.OverlayContent(observationView);
        }
        #endregion

    }
}
