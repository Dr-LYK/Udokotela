using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udokotela.ServicePatient;

namespace Udokotela.ViewModel
{
    /// <summary>
    /// Classe de ViewModel pour la fiche patient.
    /// </summary>
    public class PatientSheetViewModel : BaseViewModel
    {
        #region Attributes
        private Patient _patientToDisplay;
        #endregion

        #region Properties
        /// <summary>
        /// Numéro identifiant du patient.
        /// </summary>
        public string Id
        {
            get { return _patientToDisplay.Id.ToString(); }
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
            get { /*TODO*/ return null; }
        }
        #endregion

        #region Constructors
        #endregion

        #region Methods
        #endregion

    }
}
