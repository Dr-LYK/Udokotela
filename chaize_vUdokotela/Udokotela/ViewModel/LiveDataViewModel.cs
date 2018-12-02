using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Udokotela.Services;
using Udokotela.Utils;
using LiveCharts;
using LiveCharts.Wpf;
using Udokotela.ServiceLive;

namespace Udokotela.ViewModel
{
    public class LiveDataViewModel: BaseViewModel
    {
        #region Variables
        private readonly CSLiveData _liveDataService;
        #endregion

        #region Properties

        /// <summary>
        /// Commande pour ouvrir le panneau de live data.
        /// </summary>
        public ICommand LiveDataCommand { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur du ViewModel de connexion.
        /// </summary>
        public LiveDataViewModel()
        {
            base.DisplayName = "Udokotela - Données en temps réel";
            this._liveDataService = new CSLiveData();

        }
        #endregion

        #region Methods
        #endregion
    }
}
