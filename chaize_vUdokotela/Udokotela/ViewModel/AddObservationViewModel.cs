using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Udokotela.ServiceObservation;
using Udokotela.Services;

namespace Udokotela.ViewModel
{
    class AddObservationViewModel : BaseViewModel
    {
        #region Attributes
        private CSObservation _observationService;
        private bool _closeSignal;
        private int _patientId;
        private int _weight;
        private int _bloodPressure;
        private string[] _prescription;
        private byte[][] _pictures;
        private string _comment;
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
        /// Représente le poids durant l'observation à créer
        /// </summary>
        public int Weight
        {
            get { return _weight; }
            set
            {
                if (this._weight != value)
                {
                    this._weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }

        /// <summary>
        /// Représente la pression arterielle durant l'observation à créer
        /// </summary>
        public int BloodPressure
        {
            get { return _bloodPressure; }
            set
            {
                if (this._bloodPressure != value)
                {
                    this._bloodPressure = value;
                    OnPropertyChanged(nameof(BloodPressure));
                }
            }
        }

        /// <summary>
        /// Représente les prescriptions pour l'observation à créer
        /// </summary>
        public string[] Prescription
        {
            get { return _prescription; }
            set
            {
                if (this._prescription != value)
                {
                    this._prescription = value;
                    OnPropertyChanged(nameof(Prescription));
                }
            }
        }

        /// <summary>
        /// Représente les images de l'observation à créer
        /// </summary>
        public byte[][] Pictures
        {
            get { return _pictures; }
            set
            {
                if (this._pictures != value)
                {
                    this._pictures = value;
                    OnPropertyChanged(nameof(Pictures));
                }
            }
        }

        /// <summary>
        /// Représente le commentaire durant l'observation à créer
        /// </summary>
        public string Comment
        {
            get { return _comment; }
            set
            {
                if (this._comment != value)
                {
                    this._comment = value;
                    OnPropertyChanged(nameof(Comment));
                }
            }
        }

        /// <summary>
        /// Commande pour creer et enregistrer l'observation.
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Commande pour annuler la création de l'observation et fermer la fenêtre modale.
        /// </summary>
        public ICommand CancelCommand { get; set; }
        #endregion

        #region Constructors
        public AddObservationViewModel(int patientId)
        {
            base.DisplayName = "Ajouter une observation";
            this._observationService = new CSObservation();
            this._patientId = patientId;

            this.SaveCommand = new RelayCommand(param => Save(), param => MainWindowViewModel.CheckUserRole());
            this.CancelCommand = new RelayCommand(param => Cancel(), param => true);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Action permettant d'enregistrer l'observation.
        /// </summary>
        private void Save()
        {
            Observation newObservation = new Observation() { BloodPressure = this.BloodPressure, Comment = this.Comment, Date = DateTime.Now, Pictures = this.Pictures, Prescription = this.Prescription, Weight = this.Weight };
            bool isObservationAdded = _observationService.AddObservation(this._patientId, newObservation);
            if (isObservationAdded)
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
