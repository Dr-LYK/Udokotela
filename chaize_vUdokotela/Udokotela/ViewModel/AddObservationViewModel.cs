using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Udokotela.ServiceObservation;
using Udokotela.ServicePatient;
using Udokotela.Services;
using Udokotela.Utils;

namespace Udokotela.ViewModel
{
    /// <summary>
    /// Classe de ViewModel pour l'ajout d'une observation
    /// </summary>
    class AddObservationViewModel : BaseViewModel
    {
        #region Attributes
        private readonly Patient _patient;
        private readonly CSObservation _observationService;
        private bool _closeSignal;
        private string _weight;
        private string _bloodPressure;
        private string _prescriptionItem;
        private string _picture;
        private string _comment;
        private List<string> _prescription;
        private List<string> _pictures;
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
        /// Masse de l'individu relevé lors de l'observation.
        /// </summary>
        public string Weight
        {
            get { return _weight; }
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }


        /// <summary>
        /// Pression artérielle de l'individu relevé lors de l'observation.
        /// </summary>
        public string BloodPressure
        {
            get { return _bloodPressure; }
            set
            {
                if (_bloodPressure != value)
                {
                    _bloodPressure = value;
                    OnPropertyChanged(nameof(BloodPressure));
                }
            }
        }
        
        /// <summary>
        /// Element de prescription lors de l'observation.
        /// </summary>
        public string PrescriptionItem
        {
            get { return _prescriptionItem; }
            set
            {
                if (_prescriptionItem != value)
                {
                    _prescriptionItem = value;
                    OnPropertyChanged(nameof(PrescriptionItem));
                }
            }
        }

        /// <summary>
        /// Image associée à l'observation.
        /// </summary>
        public string Picture
        {
            get { return _picture; }
            set
            {
                if (_picture != value)
                {
                    _picture = value;
                    OnPropertyChanged(nameof(Picture));
                }
            }
        }

        /// <summary>
        /// Commentaire de l'observation.
        /// </summary>
        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    OnPropertyChanged(nameof(Picture));
                }
            }
        }

        /// <summary>
        /// Commande pour ajouter un élément à la liste de prescription.
        /// </summary>
        public ICommand AddPrescriptionItemCommand { get; set; }

        /// <summary>
        /// Commande pour ajouter une image à l'observation.
        /// </summary>
        public ICommand AddPictureCommand { get; set; }

        /// <summary>
        /// Commande pour ouvrir une navigateur de fichier afin de définir une photo à ajouter à l'observation.
        /// </summary>
        public ICommand OpenFileCommand { get; set; }
        /// <summary>
        /// Commande pour créer et enregistrer l'observation.
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Commande pour annuler la création de l'observation et fermer la fenêtre modale.
        /// </summary>
        public ICommand CancelCommand { get; set; }
        #endregion

        #region Constructors
        public AddObservationViewModel(Patient patient)
        {
            base.DisplayName = "Ajouter une observation";
            _observationService = new CSObservation();

            Weight = "";
            BloodPressure = "";
            PrescriptionItem = "";
            Picture = "";
            Comment = "";

            _patient = patient;
            _prescription = new List<string>();
            _pictures = new List<string>();

            SaveCommand = new RelayCommand(param => Save(), param => MainWindowViewModel.CheckUserRole());
            CancelCommand = new RelayCommand(param => Cancel(), param => true);
            OpenFileCommand = new RelayCommand(param => OpenFile(), param => true);
            AddPrescriptionItemCommand = new RelayCommand(param => AddPrescriptionItem(), param => true);
            AddPictureCommand = new RelayCommand(param => AddPicture(), param => true);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Action permettant d'enregistrer l'observation.
        /// </summary>
        private void Save()
        {
            string[] prescription = new string[_prescription.Count];
            for (int i = 0; i < _prescription.Count; i++)
            {
                prescription[i] = _prescription.ElementAt(i);
            }

            byte[][] pictures = new byte[_pictures.Count][];
            for (int j = 0; j < _pictures.Count; j++)
            {
                byte[] imageData = ImageLoader.Load(_pictures.ElementAt(j));
                pictures[j] = imageData;
            }

            ServiceObservation.Observation newObservation = new ServiceObservation.Observation()
            {
                Date = DateTime.Now,
                Comment = this.Comment,
                Prescription = prescription,
                Pictures = pictures,
                Weight = int.Parse(this.Weight),
                BloodPressure = int.Parse(this.BloodPressure)
            };
            bool isObservationAdded = _observationService.AddObservation(_patient.Id, newObservation);
        }

        /// <summary>
        /// Action permettant d'annuler la transaction.
        /// </summary>
        private void Cancel()
        {
            CloseSignal = true;
        }

        /// <summary>
        /// Action permettant d'ouvrir l'explorateur de fichiers.
        /// </summary>
        private void OpenFile()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "Image Files (*.jpeg;*.png;*.jpg;*.gif)|*.jpeg;*.png;*.jpg;*.gif";
            bool? result = dlg.ShowDialog();
            if (result.HasValue && result.Value)
            {
                this.Picture = dlg.FileName;
            }
        }

        /// <summary>
        /// Action permettant d'ajouter un élément à la liste de la prescription.
        /// </summary>
        private void AddPrescriptionItem()
        {
            if (PrescriptionItem != null || PrescriptionItem != "")
            {
                _prescription.Add(PrescriptionItem);
            }
        }

        /// <summary>
        /// Action permettant d'ajouter une image à la liste d'images de l'observation.
        /// </summary>
        private void AddPicture()
        {
            if (Picture != null || Picture != "")
            {
                _pictures.Add(Picture);
            }
        }
        #endregion
    }
}
