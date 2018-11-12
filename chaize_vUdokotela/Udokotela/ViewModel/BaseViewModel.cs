using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Udokotela.ViewModel
{
    /// <summary>
    /// Classe de base pour les ViewModel avec les méthodes communes.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Constructor
        /// <summary>
        /// Constructeur du ViewModel de base.
        /// </summary>
        protected BaseViewModel()
        {}
        #endregion

        #region Debugging Help
        /// <summary>
        /// Utilise la réflexion pour vérifier que l'élément lié existe bien.
        /// Ne s'active qu'à la compilation par Debug.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }

        /// <summary>
        /// Lance une exception dans le cas d'un nom de propriété invalide.
        /// </summary>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }
        #endregion

        #region INotifyPropertyChanged Members
        /// <summary>
        /// Evènement déclenché quand une propriété est changée
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Déclenche l'évenement.
        /// </summary>
        /// <param name="propertyName">Nom de la propriété qui a changé.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}
