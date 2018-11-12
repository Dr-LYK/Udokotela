using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udokotela.Model
{
    /// <summary>
    /// Classe de modèle pour l'entité observation
    /// </summary>
    public class Observation
    {
        #region properties

        /// <summary>
        /// Date d'ajout de l'observation
        /// </summary>
        public DateTime Date;

        /// <summary>
        /// Masse du patient relevé lors de l'observation
        /// </summary>
        public int Weight;

        /// <summary>
        /// Pression artérielle du patient relevé lors de l'observation
        /// </summary>
        public int BloodPressure;

        /// <summary>
        /// Commentaire de l'observation
        /// </summary>
        public string Comment;

        /// <summary>
        /// Liste des éléments de prescription lors de l'observation
        /// </summary>
        public string[] Prescription;

        /// <summary>
        /// Liste d'images associées à l'observation
        /// </summary>
        public Byte[][] Pictures;

        #endregion
    }
}
