using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Udokotela.ServiceObservation;
using Udokotela.Services;
using Udokotela.Utils;

namespace Udokotela.ViewModel
{
    class AddObservationViewModel : BaseViewModel
    {
        #region Attributes
        private readonly IParentWindow _caller;
        private readonly CSObservation _observationService;
        private bool _closeSignal;
        private int _patientId;
        private int _weight;
        private int _bloodPressure;
        private string _prescriptionItem;
        private ObservableCollection<string> _prescription;
        private string _picture;
        private ObservableCollection<byte[]> _pictures;
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
        /// Prescription item to add to Prescription property
        /// </summary>
        public string PrescriptionItem
        {
            get { return this._prescriptionItem; }
            set
            {
                if (this._prescriptionItem != value)
                {
                    this._prescriptionItem = value;
                    OnPropertyChanged(nameof(PrescriptionItem));
                }
            }
        }

        /// <summary>
        /// Représente les prescriptions pour l'observation à créer
        /// </summary>
        public ObservableCollection<string> Prescription
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
        /// Picture to add to Pictures property
        /// </summary>
        public string Picture
        {
            get { return this._picture; }
            set
            {
                if (this._picture != value)
                {
                    this._picture = value;
                    OnPropertyChanged(nameof(Picture));
                }
            }
        }

        /// <summary>
        /// Représente les images de l'observation à créer
        /// </summary>
        public ObservableCollection<byte[]> Pictures
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

        /// <summary>
        /// Commande pour ajouter une prescription à l'observation
        /// </summary>
        public ICommand AddPrescriptionItemCommand { get; set; }

        /// <summary>
        /// Commande pour ajouter une image à l'observation
        /// </summary>
        public ICommand AddPictureCommand { get; set; }

        /// <summary>
        /// Commande pour ajouter une image depuis l'explorer à l'observation
        /// </summary>
        public ICommand OpenFileCommand { get; set; }
        #endregion

        #region Constructors
        public AddObservationViewModel(int patientId, IParentWindow caller)
        {
            base.DisplayName = "Ajouter une observation";
            this._observationService = new CSObservation();
            this._patientId = patientId;
            this._caller = caller;

            this._weight = 0;
            this._bloodPressure = 0;
            this._prescriptionItem = "";
            this.Prescription = new ObservableCollection<string>();
            this._picture = "";
            this.Pictures = new ObservableCollection<byte[]>();
            this._comment = "";

            this.SaveCommand = new RelayCommand(param => Save(), param => MainWindowViewModel.CheckUserRole());
            this.CancelCommand = new RelayCommand(param => Cancel(), param => true);
            this.AddPrescriptionItemCommand = new RelayCommand(param => AddPrescriptionItem(), param => this.PrescriptionItem != null && this.PrescriptionItem.Length > 0);
            this.AddPictureCommand = new RelayCommand(param => AddPictureItem(), param => this.Picture != null && this.Picture.Length > 0);
            this.OpenFileCommand = new RelayCommand(param => OpenImageExplorer(), param => true);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Action permettant d'enregistrer l'observation.
        /// </summary>
        private void Save()
        {
            Observation newObservation = new Observation() { BloodPressure = this.BloodPressure, Comment = this.Comment, Date = DateTime.Now, Pictures = this.Pictures.ToArray(), Prescription = this.Prescription.ToArray(), Weight = this.Weight };
            bool isObservationAdded = _observationService.AddObservation(this._patientId, newObservation);
            if (isObservationAdded)
            {
                if (this._caller != null)
                {
                    this._caller.SuccessCallBack();
                }
                this.CloseSignal = true;
            }
            else
            {
                Console.WriteLine("Adding observation failed");
            }
        }

        /// <summary>
        /// Action permettant d'annuler la transaction.
        /// </summary>
        private void Cancel()
        {
            this.CloseSignal = true;
        }

        private void AddPrescriptionItem()
        {
            this.Prescription.Add(this.PrescriptionItem);
            this.PrescriptionItem = null;
        }

        private void AddPictureItem()
        {
            byte[] filecontent = ImageLoader.Load(this.Picture);
            if (filecontent != null)
            {
                this.Pictures.Add(filecontent);
            }
            else
            {
                Console.WriteLine($"Failed to load image data from {this.Picture}");
            }
            this.Picture = null;
        }

        private void OpenImageExplorer()
        {
            this.Picture = ImageLoader.SearchImageWithExplorer();
            if (this.Picture != null && this.Picture.Length > 0)
            {
                this.AddPictureItem();
            }

        }
        #endregion
    }
}
