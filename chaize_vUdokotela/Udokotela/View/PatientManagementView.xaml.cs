using System.Windows.Controls;
using Udokotela.ViewModel;

namespace Udokotela.View
{
    /// <summary>
    /// Interaction logic for PatientManagementView.xaml
    /// </summary>
    public partial class PatientManagementView : UserControl
    {
        public PatientManagementView()
        {
            InitializeComponent();
            this.DataContext = new PatientManagementViewModel();
        }
    }
}
