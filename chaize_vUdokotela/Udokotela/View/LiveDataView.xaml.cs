using System.Windows.Controls;
using Udokotela.ViewModel;

namespace Udokotela.View
{
    /// <summary>
    /// Interaction logic for LiveDataView.xaml
    /// </summary>
    public partial class LiveDataView : UserControl
    {
        public LiveDataView()
        {
            InitializeComponent();
            this.DataContext = new LiveDataViewModel();
        }
    }
}
