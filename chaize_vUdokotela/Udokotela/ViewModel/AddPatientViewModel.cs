using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Udokotela.Services;

namespace Udokotela.ViewModel
{
    public class AddPatientViewModel : BaseViewModel
    {
        #region Attributes
        private readonly CSPatient _patientService;
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
        /// Date de naissance de l'utilisateur à créer.
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
        /// Commande pour créer et enregistrer le patient.
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Commande pour annuler la création du patient et fermer la fenêtre modale.
        /// </summary>
        public ICommand CancelCommand { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur du ViewModel d'ajout d'un patient.
        /// </summary>
        public AddPatientViewModel()
        {
            base.DisplayName = "Ajouter un patient";
            _patientService = new CSPatient();

            Name = "";
            FirstName = "";

            SaveCommand = new RelayCommand(param => Save(), param => MainWindowViewModel.CheckUserRole());
            CancelCommand = new RelayCommand(param => Cancel(), param => true);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Action permettant d'enregistrer l'utilisateur.
        /// </summary>
        private void Save()
        {
            /* TODO */
        }

        /// <summary>
        /// Action permettant d'annuler la transaction.
        /// </summary>
        private void Cancel()
        {
            /* TODO */
        }
        #endregion
    }
}
