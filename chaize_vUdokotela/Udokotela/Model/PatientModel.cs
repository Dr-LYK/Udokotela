using System;
using System.Collections.Generic;

namespace Udokotela.Model
{
    /// <summary>
    /// Classe de modèle pour l'entité patient.
    /// </summary>
    public class PatientModel
    {
        #region Properties

        /// <summary>
        /// Numéro d'identification du patient.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom du patient.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Prénom du patient.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Date de naissance du patient.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Liste des observations associées au patient.
        /// </summary>
        public List<ObservationModel> Observations { get; set; }
        
        #endregion
    }
}
