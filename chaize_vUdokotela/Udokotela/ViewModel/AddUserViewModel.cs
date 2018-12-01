using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Udokotela.Services;
using Udokotela.ServiceUser;
using Udokotela.Utils;

namespace Udokotela.ViewModel
{
    public class AddUserViewModel : BaseViewModel
    {
        #region Attributes
        private readonly CSUser _userService;
        private bool _closeSignal;
        private string _name;
        private string _firstName;
        private string _role;
        private string _picture;
        private string _login;
        private SecureString _password;
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
        /// Nom de famille de l'utilisateur à créer.
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
        /// Prénom de l'utilisateur à créer.
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
        /// Rôle de l'utilisateur à créer.
        /// </summary>
        public string Role
        {
            get { return _role; }
            set
            {
                if (_role != value)
                {
                    _role = value;
                    OnPropertyChanged(nameof(Role));
                }
            }
        }

        /// <summary>
        /// Photo de profil de l'utilisateur à créer.
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
        /// Identifiant de l'utilisateur à créer.
        /// </summary>
        public string Login
        {
            get { return _login; }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged(nameof(Login));
                }
            }
        }

        /// <summary>
        /// Mot de passe de l'utilisateur à créer.
        /// </summary>
        public SecureString Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        /// <summary>
        /// Commande pour ouvrir une navigateur de fichier afin de définir une photo de profil pour l'utilisateur.
        /// </summary>
        public ICommand OpenFileCommand { get; set; }

        /// <summary>
        /// Commande pour créer et enregistrer l'utilisateur.
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Commande pour annuler la création de l'utilisateur et fermer la fenêtre modale.
        /// </summary>
        public ICommand CancelCommand { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur du ViewModel d'ajout d'un utilisateur.
        /// </summary>
        public AddUserViewModel()
        {
            base.DisplayName = "Ajouter un utilisateur";
            _userService = new CSUser();

            Name = "";
            FirstName = "";
            Role = "";
            Picture = "";
            Login = "";
            Password = new SecureString();

            SaveCommand = new RelayCommand(param => Save(), param => MainWindowViewModel.CheckUserRole());
            CancelCommand = new RelayCommand(param => Cancel(), param => true);
            OpenFileCommand = new RelayCommand(param => OpenFile(), param => true);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Action permettant d'enregistrer l'utilisateur.
        /// </summary>
        private void Save()
        {
            byte[] imageData = ImageLoader.Load(this._picture);
            User newUser = new User() { Connected = false, Firstname = this._firstName, Login = this._login, Name = this._name, Picture = imageData, Pwd = Converter.SecureStringToString(this._password), Role = this._role };
            bool isUserAdded =_userService.AddUser(newUser);
            if (isUserAdded)
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
        #endregion
    }
}
