using System;

namespace Udokotela.Model
{
    /// <summary>
    /// Classe de modèle pour l'entité donnée.
    /// </summary>
    class DataModel
    {
        #region Properties

        /// <summary>
        /// Fréquence cardiaque de la donnée envoyée.
        /// </summary>
        public int HeartRate { get; set; }

        /// <summary>
        /// Température de la donnée envoyée.
        /// </summary>
        public int Temperature { get; set; }

        /// <summary>
        /// Date et heure d'envoi de la fréquence cardiaque.
        /// </summary>
        public DateTime HeartRateDateTime { get; set; }

        /// <summary>
        /// Date et heure d'envoi de la température.
        /// </summary>
        public DateTime TemperatureDateTime { get; set; }

        #endregion
    }
}
