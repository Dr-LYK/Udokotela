using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udokotela.ServiceObservation;
using Udokotela.ServicePatient;

namespace Udokotela.ViewModel
{
    class ObservationSheetViewModel : BaseViewModel
    {
        #region Attributes
        private Patient _patientToDisplay;
        private ServiceObservation.Observation _observationToDisplay;
        private MainWindowViewModel _mainView;
        #endregion

        #region Properties
        /// <summary>
        /// Date d'ajout de l'observation.
        /// </summary>
        public string Date
        {
            get { return _observationToDisplay.Date.ToString("g", CultureInfo.CreateSpecificCulture("fr-FR")); }
        }

        /// <summary>
        /// Masse de l'individu relevée lors de l'observation.
        /// </summary>
        public string Weight
        {
            get { return _observationToDisplay.Weight.ToString(); }
        }

        /// <summary>
        /// Pression artérielle de l'individu relevée lors de l'observation.
        /// </summary>
        public string BloodPressure
        {
            get { return _observationToDisplay.BloodPressure.ToString(); }
        }

        /// <summary>
        /// Numéro identifiant du patient.
        /// </summary>
        public string Id
        {
            get { return _patientToDisplay.Id.ToString(); }
        }

        /// <summary>
        /// Nom du patient.
        /// </summary>
        public string Name
        {
            get { return _patientToDisplay.Name; }
        }

        /// <summary>
        /// Prénom du patient.
        /// </summary>
        public string Firstname
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
        #endregion
    }
}
