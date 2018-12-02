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
    public class AddPatientViewModel : BaseViewModel
    {
        #region Attributes
        private CSPatient _patientService;
        private bool _closeSignal;
        private string _name;
        private string _firstName;
        private DateTime _birthdate;
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
        /// Nom de famille du patient à créer.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// Prénom du patient à créer.
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        /// <summary>
        /// Date de naissance du patient.
        /// </summary>
        public DateTime Birthdate
        {
            get { return _birthdate; }
            set
            {
                if (_birthdate != value)
                {
                    _birthdate = value;
                    OnPropertyChanged(nameof(Birthdate));
                }
            }
        }

        /// <summary>
        /// Represent current date
        /// </summary>
        public DateTime DateTimeNow
        {
            get { return DateTime.Now; }
        }

        /// <summary>
        /// Commande pour creer et enregistrer l'utilisateur.
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Commande pour annuler la création de l'utilisateur et fermer la fenêtre modale.
        /// </summary>
        public ICommand CancelCommand { get; set; }
        #endregion

        #region Constructors
        public AddPatientViewModel()
        {
            base.DisplayName = "Ajouter un patient";
            this._patientService = new CSPatient();

            this.Name = "";
            this.FirstName = "";
            this.Birthdate = DateTime.Now;

            this.SaveCommand = new RelayCommand(param => Save(), param => MainWindowViewModel.CheckUserRole());
            this.CancelCommand = new RelayCommand(param => Cancel(), param => true);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Action permettant d'enregistrer le patient.
        /// </summary>
        private void Save()
        {
            Patient newPatient = new Patient() { Birthday = this._birthdate, Firstname = this._firstName, Name = this._name };
            bool isPatientAdded =_patientService.AddPatient(newPatient);
            if (isPatientAdded)
            {
                this.CloseSignal = true;
            }
            else
            {
                // TODO
                // Behavior in case save failed
            }
        }

        /// <summary>
        /// Action permettant d'annuler la transaction.
        /// </summary>
        private void Cancel()
        {
            this.CloseSignal = true;
        }
        #endregion
    }
}
