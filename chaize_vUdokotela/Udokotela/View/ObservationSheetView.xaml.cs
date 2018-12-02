using System.Windows.Controls;
using Udokotela.ServicePatient;
using Udokotela.ViewModel;

namespace Udokotela.View
{
    /// <summary>
    /// Interaction logic for ObservationSheetView.xaml
    /// </summary>
    public partial class ObservationSheetView : UserControl
    {
        public ObservationSheetView(Patient patient, ServiceObservation.Observation observation, MainWindowViewModel mainView)
        {
            InitializeComponent();
            this.DataContext = new ObservationSheetViewModel(patient, observation, mainView);
        }
    }
}
